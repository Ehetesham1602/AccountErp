
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Report;
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
        public async Task<List<VendorReportsDto>>GetVendorReportAsync(VendorReportsDto model)
        {
            List<VendorReportsDto> vendorReportsList = await (from v in _dataContext.Vendors
                                                        select new VendorReportsDto
                                                        {
                                                            Id = v.Id,
                                                            VendorName = v.Name,
                                                            TotalAmount = model.TotalAmount,
                                                            TotalPaidAmount = model.TotalPaidAmount

                                                        }).ToListAsync();

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
    }
}
