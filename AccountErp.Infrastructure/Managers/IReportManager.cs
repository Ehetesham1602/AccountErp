﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountErp.Dtos;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Customer;
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
    }
}
