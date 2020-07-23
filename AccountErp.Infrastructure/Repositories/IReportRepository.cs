using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Customer;
using AccountErp.Dtos.Report;
using AccountErp.Models.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IReportRepository
    {
        Task<List<VendorReportsDto>> GetVendorReportAsync(VendorReportModel model);

        Task<List<CustomerReportsDto>> GetCustomerReportAsync(CustomerReportModel model);

        Task<List<SalesTaxReportDto>> GetSalesTaxReportAsync(SalesReportModel model);

        Task<List<AgedPayablesReportDto>> GetAgedPayablesReportAsync(AgedPayablesModel model);
        Task<List<AgedPayablesReportDto>> GetAgedReceivablesReportAsync(AgedReceivablesModel model);
        Task<ProfitAndLossSummaryReportDto> GetProfitAndLossReportAsync(ProfitAndLossModel model);
    }
}
