
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Customer;
using AccountErp.Dtos.Invoice;
using AccountErp.Dtos.RecurringInvoice;
using AccountErp.Dtos.Report;
using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace AccountErp.DataLayer.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly DataContext _dataContext;

        public ReportRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<VendorReportsDto>> GetVendorReportAsync(VendorReportsDto model)
        {
            List<VendorReportsDto> vendorReportsList;
            if (model.Id == 0)
            {
                vendorReportsList = await (from v in _dataContext.Vendors
                                           select new VendorReportsDto
                                           {
                                               Id = v.Id,
                                               VendorName = v.Name,
                                               TotalAmount = model.TotalAmount,
                                               TotalPaidAmount = model.TotalPaidAmount

                                           }).ToListAsync();

            }
            else
            {
                vendorReportsList = await (from v in _dataContext.Vendors
                                           where v.Id == model.Id
                                           select new VendorReportsDto
                                           {
                                               Id = v.Id,
                                               VendorName = v.Name,
                                               TotalAmount = model.TotalAmount,
                                               TotalPaidAmount = model.TotalPaidAmount

                                           }).ToListAsync();

            }

            foreach (var item in vendorReportsList)
            {
                List<BillSummaryDto> billSummaryDtosList = await (from b in _dataContext.Bills
                                                                  where b.VendorId == item.Id && b.Status != Constants.BillStatus.Deleted
                                                                  select new BillSummaryDto
                                                                  {
                                                                      TotalAmount = b.TotalAmount,
                                                                      status = b.Status,
                                                                      BillDate = b.BillDate
                                                                  }).ToListAsync();

                billSummaryDtosList = billSummaryDtosList.Where(p => (p.BillDate >= model.startDate && p.BillDate <= model.endDate)).ToList();

                item.TotalAmount = billSummaryDtosList.Sum(x => x.TotalAmount);
                item.TotalPaidAmount = billSummaryDtosList.Where(x => x.status == Constants.BillStatus.Paid).Sum(x => x.TotalAmount);
            }

            return vendorReportsList;

        }

        public async Task<List<CustomerReportsDto>> GetCustomerReportAsync(CustomerReportsDto model)
        {
            List<CustomerReportsDto> customerReportsDtoList = await (from c in _dataContext.Customers
                                                                     select new CustomerReportsDto
                                                                     {
                                                                         Id = c.Id,
                                                                         CustomerName = c.FirstName + " " + c.MiddleName + " " + c.LastName,
                                                                         IncomeAmount = model.IncomeAmount,
                                                                         PaidAmount = model.PaidAmount

                                                                     }).ToListAsync();
            foreach (var invoice in customerReportsDtoList)
            {
                List<InvoiceListItemDto> invoiceListItemDtosList = await (from v in _dataContext.Invoices
                                                                          where v.CustomerId == invoice.Id && v.Status != Constants.InvoiceStatus.Deleted
                                                                          select new InvoiceListItemDto
                                                                          {
                                                                              TotalAmount = v.TotalAmount,
                                                                              Status = v.Status,
                                                                              InvoiceDate = v.InvoiceDate
                                                                          }).ToListAsync();
                invoiceListItemDtosList = invoiceListItemDtosList.Where(p => (p.InvoiceDate >= model.StartDate && p.InvoiceDate <= model.EndDate)).ToList();
                invoice.IncomeAmount = invoiceListItemDtosList.Sum(x => x.TotalAmount);
                invoice.PaidAmount = invoiceListItemDtosList.Where(x => x.Status == Constants.InvoiceStatus.Paid).Sum(x => x.TotalAmount);
            }
            return customerReportsDtoList;
        }
    }
}
