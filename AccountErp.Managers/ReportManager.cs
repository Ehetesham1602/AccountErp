using AccountErp.Dtos;
using AccountErp.Dtos.BankAccount;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.ChartofAccount;
using AccountErp.Dtos.Customer;
using AccountErp.Dtos.Report;
using AccountErp.Entities;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Customer;
using AccountErp.Models.Report;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public ReportManager(IHttpContextAccessor contextAccessor,
            IReportRepository reportRepository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<VendorDetailsReportDto> GetVendorReportAsync(VendorReportModel model)
        {
            VendorDetailsReportDto vendorDetailsReportDtoObj = new VendorDetailsReportDto();
            List<VendorReportsDto> tempModel = await _reportRepository.GetVendorReportAsync(model);

            vendorDetailsReportDtoObj.vendorReportsList = tempModel;
            vendorDetailsReportDtoObj.TotalPurchaseAmount = tempModel.Sum(x => x.TotalAmount);
            vendorDetailsReportDtoObj.TotalPaidAmount = tempModel.Sum(x => x.TotalPaidAmount);
            /* foreach (BillSummaryDto billSummary in tempModel)
            {
                billSummary.paidAmount = (billSummary.status == "1") ? billSummary.TotalAmount : 0;

            }
           */
            return vendorDetailsReportDtoObj;
        }

        public async Task<CustomerDetailsReportDto> GetCustomerReportAsync(CustomerReportModel model)
        {
            CustomerDetailsReportDto customerDetailsReportDtoObj = new CustomerDetailsReportDto();
            List<CustomerReportsDto> customerList = await _reportRepository.GetCustomerReportAsync(model);
            customerDetailsReportDtoObj.customerReportsDtosList = customerList;
            customerDetailsReportDtoObj.TotalIncome = customerList.Sum(x => x.IncomeAmount);
            customerDetailsReportDtoObj.TotaPaidIncome = customerList.Sum(x => x.PaidAmount);
            return customerDetailsReportDtoObj;
        }
        
        public async Task<SalesTaxDetailsReportDto> GetSalesTaxReportAsync(SalesReportModel model)
        {

            SalesTaxDetailsReportDto salesTaxDetailsReportDtoObj = new SalesTaxDetailsReportDto();
            List<SalesTaxReportDto> salesTaxReportDtosList = await _reportRepository.GetSalesTaxReportAsync(model);
            salesTaxDetailsReportDtoObj.SalesTaxReportDtosList = salesTaxReportDtosList;
            salesTaxDetailsReportDtoObj.TotalTaxAmountOnSales = salesTaxReportDtosList.Sum(x => x.TaxAmountOnSales);
            salesTaxDetailsReportDtoObj.TotalTaxAmountOnPurchase = salesTaxReportDtosList.Sum(x => x.TaxAmountOnPurchases);
            salesTaxDetailsReportDtoObj.TotalNetTaxOwing = salesTaxReportDtosList.Sum(x => x.NetTaxOwing);
            salesTaxDetailsReportDtoObj.TotalNetTaxOwing = salesTaxReportDtosList.Sum(x => x.NetTaxOwing);
            salesTaxDetailsReportDtoObj.TotalStartingBalance = salesTaxReportDtosList.Sum(x => x.StartingBalance);
            salesTaxDetailsReportDtoObj.TotalLessPaymentsToGovernment = salesTaxReportDtosList.Sum(x => x.LessPaymentsToGovernment);
            salesTaxDetailsReportDtoObj.TotalEndingBalance = salesTaxReportDtosList.Sum(x => x.EndingBalance);
            return salesTaxDetailsReportDtoObj;
        }

        public async Task<AgedPayablesDetailsReportDto> GetAgedPayablesReportAsync(AgedPayablesModel model)
        {
            AgedPayablesDetailsReportDto agedPayablesDetailsReportDtoObj = new AgedPayablesDetailsReportDto();
            List<AgedPayablesReportDto> agedPayablesReportDtosList = await _reportRepository.GetAgedPayablesReportAsync(model);
            agedPayablesDetailsReportDtoObj.AgedPayablesReportDtoList = agedPayablesReportDtosList;
            agedPayablesDetailsReportDtoObj.TotalAmount = agedPayablesReportDtosList.Sum(x => x.TotalAmount);
            agedPayablesDetailsReportDtoObj.TotalUnpaidAmount = agedPayablesReportDtosList.Sum(x => x.TotalUnpaid);
            agedPayablesDetailsReportDtoObj.TotalLessThan30 = agedPayablesReportDtosList.Sum(x => x.LessThan30);
            agedPayablesDetailsReportDtoObj.TotalCountLessThan30 = agedPayablesReportDtosList.Sum(x => x.CountLessThan30);
            agedPayablesDetailsReportDtoObj.TotalThirtyFirstToSixty = agedPayablesReportDtosList.Sum(x => x.ThirtyFirstToSixty);
            agedPayablesDetailsReportDtoObj.TotalCountThirtyFirstToSixty = agedPayablesReportDtosList.Sum(x => x.CountThirtyFirstToSixty);
            agedPayablesDetailsReportDtoObj.TotalSixtyOneToNinety = agedPayablesReportDtosList.Sum(x => x.SixtyOneToNinety);
            agedPayablesDetailsReportDtoObj.TotalCountSixtyOneToNinety = agedPayablesReportDtosList.Sum(x => x.CountSixtyOneToNinety);
            agedPayablesDetailsReportDtoObj.TotalMoreThanNinety = agedPayablesReportDtosList.Sum(x => x.MoreThanNinety);
            agedPayablesDetailsReportDtoObj.TotalCountMoreThanNinety = agedPayablesReportDtosList.Sum(x => x.CountMoreThanNinety);
            agedPayablesDetailsReportDtoObj.TotalNotYetOverDue = agedPayablesReportDtosList.Sum(x => x.NotYetOverDue);
            agedPayablesDetailsReportDtoObj.TotalCountNotYetOverDue = agedPayablesReportDtosList.Sum(x => x.CountNotYetOverDue);
            return agedPayablesDetailsReportDtoObj;
        }

        public async Task<AgedPayablesDetailsReportDto> GetAgedReceivablesReportAsync(AgedReceivablesModel model)
        {
            AgedPayablesDetailsReportDto agedReceivablesDetailsReportDtoObj = new AgedPayablesDetailsReportDto();
            List<AgedReceivablesReportDto> agedReceivablesReportDtoList = await _reportRepository.GetAgedReceivablesReportAsync(model);
            agedReceivablesDetailsReportDtoObj.AgedReceivablesReportDtoList = agedReceivablesReportDtoList;
            agedReceivablesDetailsReportDtoObj.TotalAmount = agedReceivablesReportDtoList.Sum(x => x.TotalAmount);
            agedReceivablesDetailsReportDtoObj.TotalUnpaidAmount = agedReceivablesReportDtoList.Sum(x => x.TotalUnpaid);
            agedReceivablesDetailsReportDtoObj.TotalLessThan30 = agedReceivablesReportDtoList.Sum(x => x.LessThan30);
            agedReceivablesDetailsReportDtoObj.TotalCountLessThan30 = agedReceivablesReportDtoList.Sum(x => x.CountLessThan30);
            agedReceivablesDetailsReportDtoObj.TotalThirtyFirstToSixty = agedReceivablesReportDtoList.Sum(x => x.ThirtyFirstToSixty);
            agedReceivablesDetailsReportDtoObj.TotalCountThirtyFirstToSixty = agedReceivablesReportDtoList.Sum(x => x.CountThirtyFirstToSixty);
            agedReceivablesDetailsReportDtoObj.TotalSixtyOneToNinety = agedReceivablesReportDtoList.Sum(x => x.SixtyOneToNinety);
            agedReceivablesDetailsReportDtoObj.TotalCountSixtyOneToNinety = agedReceivablesReportDtoList.Sum(x => x.CountSixtyOneToNinety);
            agedReceivablesDetailsReportDtoObj.TotalMoreThanNinety = agedReceivablesReportDtoList.Sum(x => x.MoreThanNinety);
            agedReceivablesDetailsReportDtoObj.TotalCountMoreThanNinety = agedReceivablesReportDtoList.Sum(x => x.CountMoreThanNinety);
            agedReceivablesDetailsReportDtoObj.TotalNotYetOverDue = agedReceivablesReportDtoList.Sum(x => x.NotYetOverDue);
            agedReceivablesDetailsReportDtoObj.TotalCountNotYetOverDue = agedReceivablesReportDtoList.Sum(x => x.CountNotYetOverDue);
            return agedReceivablesDetailsReportDtoObj;
        }
         
        public async Task<ProfitAndLossSummaryReportDto> GetProfitAndLossReportAsync(ProfitAndLossModel model)
        {
            ProfitAndLossSummaryReportDto profitAndLossSummaryReportDtosList = new ProfitAndLossSummaryReportDto();
            ProfitAndLossSummaryDetailsReportDto profitAndLossSummaryList = await _reportRepository.GetProfitAndLossReportAsync(model);

            profitAndLossSummaryReportDtosList.Income = 0;
            profitAndLossSummaryReportDtosList.OperatingExpenses = 0;
            profitAndLossSummaryReportDtosList.CostOfGoodSold = 0;

            if (model.ReportType == 1)
            {
                profitAndLossSummaryList.billDetailDto = profitAndLossSummaryList.billDetailDto.Where(p => p.Status == Constants.BillStatus.Paid).ToList();
                profitAndLossSummaryList.InvoiceDetailDto = profitAndLossSummaryList.InvoiceDetailDto.Where(p => p.Status == Constants.InvoiceStatus.Paid).ToList();
            }
            profitAndLossSummaryList.billDetailDto = profitAndLossSummaryList.billDetailDto.Where(p => (p.BillDate >= model.StartDate && p.BillDate <= model.EndDate)).ToList();
            profitAndLossSummaryList.InvoiceDetailDto = profitAndLossSummaryList.InvoiceDetailDto.Where(p => (p.InvoiceDate >= model.StartDate && p.InvoiceDate <= model.EndDate)).ToList();


            foreach (var item in profitAndLossSummaryList.InvoiceDetailDto)
            {
                profitAndLossSummaryReportDtosList.Income += item.SubTotal;
            }

            foreach (var bill in profitAndLossSummaryList.billDetailDto)
            {
                profitAndLossSummaryReportDtosList.OperatingExpenses += bill.SubTotal;
            }

            profitAndLossSummaryReportDtosList.NetProfit = profitAndLossSummaryReportDtosList.Income - profitAndLossSummaryReportDtosList.CostOfGoodSold - profitAndLossSummaryReportDtosList.OperatingExpenses;
            return profitAndLossSummaryReportDtosList;
        }
        public async Task<List<TrialBalanceReportDto>> GetTrialBalance(TrialBalanaceReportModel model)
        {
            var data = await _reportRepository.GetCOADetailAsyncForTrialReport();

            List<TrialBalanceReportDto> accountDetailDto = new List<TrialBalanceReportDto>();
            foreach (var item in data)
            {
                TrialBalanceReportDto accountMasterDto = new TrialBalanceReportDto();
                accountMasterDto.Id = item.Id;
                accountMasterDto.AccountMasterName = item.AccountMasterName;
                accountMasterDto.BankAccount = new List<TrialBalanceAccountDetailDto>();
                foreach (var accType in item.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                        if(model.ReportType == 0)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate <= model.AsOfDate)).ToList();
                        }
                        else if(model.ReportType == 1)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate <= model.AsOfDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
                        }
                      
                        TrialBalanceAccountDetailDto trialAcc = new TrialBalanceAccountDetailDto();
                        trialAcc.Id = acc.Id;
                        trialAcc.AccountName = acc.AccountName;
                        trialAcc.CreditAmount = acc.Transactions.Sum(x => x.CreditAmount);
                        trialAcc.DebitAmount = acc.Transactions.Sum(x => x.DebitAmount);
                        accountMasterDto.BankAccount.Add(trialAcc);
                    }
                }
                TrialBalanceAccountDetailDto trialTotalAcc = new TrialBalanceAccountDetailDto();
                trialTotalAcc.AccountName = "Total " + item.AccountMasterName;
                trialTotalAcc.CreditAmount = accountMasterDto.BankAccount.Sum(x => x.CreditAmount);
                trialTotalAcc.DebitAmount = accountMasterDto.BankAccount.Sum(x => x.DebitAmount);
                accountMasterDto.BankAccount.Add(trialTotalAcc);
                accountDetailDto.Add(accountMasterDto);
            }
            return accountDetailDto;
        }
    }
}
