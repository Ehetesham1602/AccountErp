
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Customer;
using AccountErp.Dtos.Invoice;
using AccountErp.Dtos.Item;
using AccountErp.Dtos.RecurringInvoice;
using AccountErp.Dtos.Report;
using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Report;
using AccountErp.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
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
        public async Task<List<VendorReportsDto>> GetVendorReportAsync(VendorReportModel model)
        {
            List<VendorReportsDto> vendorReportsList;
            if (model.VendorId == 0)
            {
                vendorReportsList = await (from v in _dataContext.Vendors
                                           select new VendorReportsDto
                                           {
                                               VendorId = v.Id,
                                               VendorName = v.Name
                                               /*TotalAmount = model.TotalAmount,
                                               TotalPaidAmount = model.TotalPaidAmount*/

                                           }).ToListAsync();

            }
            else
            {
                vendorReportsList = await (from v in _dataContext.Vendors
                                           where v.Id == model.VendorId
                                           select new VendorReportsDto
                                           {
                                               VendorId = v.Id,
                                               VendorName = v.Name
                                               /*  TotalAmount = model.TotalAmount,
                                                 TotalPaidAmount = model.TotalPaidAmount*/

                                           }).ToListAsync();

            }

            foreach (var item in vendorReportsList)
            {
                List<BillSummaryDto> billSummaryDtosList = await (from b in _dataContext.Bills
                                                                  where b.VendorId == item.VendorId && b.Status != Constants.BillStatus.Deleted
                                                                  select new BillSummaryDto
                                                                  {
                                                                      TotalAmount = b.TotalAmount,
                                                                      status = b.Status,
                                                                      BillDate = b.BillDate
                                                                  }).ToListAsync();

                billSummaryDtosList = billSummaryDtosList.Where(p => (p.BillDate >= model.StartDate && p.BillDate <= model.EndDate)).ToList();

                item.TotalAmount = billSummaryDtosList.Sum(x => x.TotalAmount);
                item.TotalPaidAmount = billSummaryDtosList.Where(x => x.status == Constants.BillStatus.Paid).Sum(x => x.TotalAmount);
            }

            return vendorReportsList;

        }

        public async Task<List<CustomerReportsDto>> GetCustomerReportAsync(CustomerReportModel model)
        {
            List<CustomerReportsDto> customerReportsDtoList;
            if (model.CustomerId == 0)
            {
                customerReportsDtoList = await (from c in _dataContext.Customers
                                                select new CustomerReportsDto
                                                {
                                                    CustomerId = c.Id,
                                                    CustomerName = c.FirstName + " " + c.MiddleName + " " + c.LastName,
                                                    /*IncomeAmount = model.IncomeAmount,
                                                    PaidAmount = model.PaidAmount*/

                                                }).ToListAsync();
            }
            else
            {
                customerReportsDtoList = await (from c in _dataContext.Customers
                                                where c.Id == model.CustomerId
                                                select new CustomerReportsDto
                                                {
                                                    CustomerId = c.Id,
                                                    CustomerName = c.FirstName + " " + c.MiddleName + " " + c.LastName,
                                                    /*  IncomeAmount = model.IncomeAmount,
                                                      PaidAmount = model.PaidAmount*/

                                                }).ToListAsync();
            }

            foreach (var invoice in customerReportsDtoList)
            {
                List<InvoiceListItemDto> invoiceListItemDtosList = await (from v in _dataContext.Invoices
                                                                          where v.CustomerId == invoice.CustomerId && v.Status != Constants.InvoiceStatus.Deleted
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

        public async Task<List<SalesTaxReportDto>> GetSalesTaxReportAsync(SalesReportModel model)
        {
            List<SalesTaxReportDto> salesTaxReportDtosList;
            List<InvoiceDetailDto> invoiceDetailDtoList;
            List<BillDetailDto> billDetailDtoList;
           if(model.SalesId == 0)
            {
                salesTaxReportDtosList = await (from s in _dataContext.SalesTaxes
                                                select new SalesTaxReportDto
                                                {
                                                    SalesId = s.Id,
                                                    Tax = s.TaxPercentage + " " + s.Code
                                                }).ToListAsync();
            }
            else
            {
                salesTaxReportDtosList = await (from s in _dataContext.SalesTaxes
                                                where s.Id == model.SalesId
                                                select new SalesTaxReportDto
                                                {
                                                    SalesId = s.Id,
                                                    Tax = s.TaxPercentage + " " + s.Code
                                                }).ToListAsync();
            }
            
            foreach (var salesTax in salesTaxReportDtosList)
            {
                invoiceDetailDtoList = await (from i in _dataContext.InvoiceServices
                                              join s in _dataContext.Invoices on i.InvoiceId equals s.Id
                                               where i.TaxId == salesTax.SalesId
                                               && s.Status != Constants.InvoiceStatus.Deleted 
                                               && s.Status != Constants.InvoiceStatus.Overdue
                                              select new InvoiceDetailDto
                                              {
                                                  Status = s.Status,
                                                  InvoiceDate = s.InvoiceDate,
                                                  InvoiceServiceDto = new InvoiceServiceDto
                                                  {
                                                      Rate = i.Rate,
                                                      Price = i.Price,
                                                      TaxPrice = i.TaxPrice
                                                  }

                                              }).ToListAsync();
                if (model.ReportType == 1)
                {
                    invoiceDetailDtoList = invoiceDetailDtoList.Where(p => p.Status == Constants.InvoiceStatus.Paid).ToList();
                } 
                invoiceDetailDtoList = invoiceDetailDtoList.Where(p => (p.InvoiceDate >= model.StartDate && p.InvoiceDate <= model.EndDate )).ToList();
                salesTax.SalesSubjectToTax = invoiceDetailDtoList.Sum(x => x.InvoiceServiceDto.Price);
                salesTax.TaxAmountOnSales = invoiceDetailDtoList.Sum(x => x.InvoiceServiceDto.TaxPrice);

                billDetailDtoList = await (from b in _dataContext.BillItems
                                              join bs in _dataContext.Bills on b.BillId equals bs.Id
                                              where b.TaxId == salesTax.SalesId
                                              && bs.Status != Constants.BillStatus.Deleted
                                           select new BillDetailDto
                                              {
                                                  Status = bs.Status,
                                                  BillDate = bs.BillDate,
                                                 Bill = new BillServiceDto
                                                 {
                                                     Rate = b.Rate,
                                                     Price = b.Price,
                                                     TaxPrice = b.TaxPrice
                                                 }

                                              }).ToListAsync();
                if(model.ReportType == 1)
                {
                    billDetailDtoList = billDetailDtoList.Where(p => p.Status == Constants.BillStatus.Paid).ToList();
                }
                billDetailDtoList = billDetailDtoList.Where(p => (p.BillDate >= model.StartDate && p.BillDate <= model.EndDate)).ToList();
                salesTax.PurchaseSubjectToTax = billDetailDtoList.Sum(x => x.Bill.Price);
                salesTax.TaxAmountOnPurchases = billDetailDtoList.Sum(x => x.Bill.TaxPrice);
                //Expression exp = Expression.Subtract(Expression.Constant(salesTax.TaxAmountOnSales), Expression.Constant(salesTax.TaxAmountOnPurchases));
                //salesTax.NetTaxOwing = exp.
                salesTax.NetTaxOwing = salesTax.TaxAmountOnSales - salesTax.TaxAmountOnPurchases;
            }
            return salesTaxReportDtosList;
        }

        public async Task<List<AgedPayablesReportDto>> GetAgedPayablesReportAsync(AgedPayablesModel model)
        {
            List<AgedPayablesReportDto> agedPayablesReportsList;
            List<BillDetailDto> billDetailDtoList;
            var daysPassed = (DateTime.UtcNow - model.AsOfDate).Days;
            agedPayablesReportsList = await (from v in _dataContext.Vendors
                                             select new AgedPayablesReportDto
                                             {
                                                 VendorId = v.Id,
                                                 VendorName = v.Name
                                             }).ToListAsync();
            foreach (var agedPayables in agedPayablesReportsList)
            {
                
                billDetailDtoList = await (from b in _dataContext.Bills
                                            where b.Status != Constants.BillStatus.Deleted
                                            select new BillDetailDto
                                            {
                                                TotalAmount = b.TotalAmount
                                            }).ToListAsync();
               /* if (daysPassed > 30)
                {
                    
                    agedPayables.TotalUnpaid = billDetailDtoList.Sum(x => x.TotalAmount);
                }*/
                billDetailDtoList = billDetailDtoList.Where(p => (p.DueDate >= model.AsOfDate)).ToList();
                agedPayables.TotalUnpaid = billDetailDtoList.Sum(x => x.TotalAmount);
            }
            return agedPayablesReportsList;
        }
    }
}
