﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountErp.Dtos.Report;
using AccountErp.Models.Report;

namespace AccountErp.Infrastructure.Managers
{
    public interface IReportManager
    {
        Task<VendorDetailsReportDto> GetVendorReportAsync(VendorReportModel model);
        Task<CustomerDetailsReportDto> GetCustomerReportAsync(CustomerReportModel model);
        Task<SalesTaxDetailsReportDto> GetSalesTaxReportAsync(SalesReportModel model);
        Task<AgedPayablesDetailsReportDto> GetAgedPayablesReportAsync(AgedPayablesModel model);
        Task<AgedPayablesDetailsReportDto> GetAgedReceivablesReportAsync(AgedReceivablesModel model);
        Task<ProfitAndLossSummaryReportDto> GetProfitAndLossReportAsync(ProfitAndLossModel model);
        Task<List<TrialBalanceReportDto>> GetTrialBalance(TrialBalanaceReportModel model);
        Task<AccountTotalBalanceDto> GetAccountBalanceReportAsync(AccountBalanceModel model);
        Task<ProfitAndLossMainDto> GetProfitAndLossDetailsReportAsync(ProfitAndLossModel model);
        Task<List<BalanceSheetReportDto>> GetBalanceSheetReportAsync(BalanceSheetModel model);
        Task<List<CashFlowReportDto>> GetCashFlowReportAsync(CashFlowModel model);
        //Task<CashFlowReportDto> GetCashFlowReportAsync(CashFlowModel model);

    }
}
