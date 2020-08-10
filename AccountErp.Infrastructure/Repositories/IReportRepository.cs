﻿using AccountErp.Dtos.Bill;
using AccountErp.Dtos.ChartofAccount;
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
        Task<List<AgedReceivablesReportDto>> GetAgedReceivablesReportAsync(AgedReceivablesModel model);
        Task<ProfitAndLossSummaryDetailsReportDto> GetProfitAndLossReportAsync(ProfitAndLossModel model);
        Task<List<COADetailDto>> GetCOADetailAsyncForTrialReport();
        Task<List<COADetailDto>> GetAccountBalanceReportAsync();
        Task<List<COADetailDto>> GetProfitAndLossDetailsReportAsync();
        /*        Task<List<AccountBalanceAccountDetailDto>> GetAccountBalanceReportAsync(AccountBalanceModel model);
        */
        //Task<ProfitAndLossDetailsReportDto> GetProfitAndLossDetailsReportAsync(ProfitAndLossModel model);
        //Task<List<COADetailDto>> GetProfitAndLossDetailsReportAsync(ProfitAndLossModel model);
    }
}
