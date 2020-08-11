﻿using AccountErp.Dtos;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
            ProfitAndLossSummaryDetailsReportDto profitAndLossSummaryList;
            profitAndLossSummaryList = await _reportRepository.GetProfitAndLossReportAsync(model);
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
                        if (model.ReportType == 0)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate <= model.AsOfDate)).ToList();
                        }
                        else if (model.ReportType == 1)
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
        public async Task<AccountTotalBalanceDto> GetAccountBalanceReportAsync(AccountBalanceModel model)
        {
            var data = await _reportRepository.GetAccountBalanceReportAsync();

            List<AccountBalanceReportDto> accountBalanceList = new List<AccountBalanceReportDto>();
            AccountBalanceReportDto accBalObj = new AccountBalanceReportDto();
            AccountTotalBalanceDto accountTotalBalanceDtoObj = new AccountTotalBalanceDto();

            foreach (var item in data)
            {
                AccountBalanceReportDto accountMasterDto = new AccountBalanceReportDto();
                accountMasterDto.Id = item.Id;
                accountMasterDto.AccountMasterName = item.AccountMasterName;
                accountMasterDto.BankAccount = new List<AccountBalanceAccountDetailDto>();
                foreach (var accType in item.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                        var bank = acc.Transactions.Where(p => (p.TransactionDate <= model.StartDate)).ToList();
                        var invAmount = bank.Sum(x => x.DebitAmount);

                        acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate)).ToList();

                        AccountBalanceAccountDetailDto AccountBalance = new AccountBalanceAccountDetailDto();
                        AccountBalance.Id = acc.Id;
                        AccountBalance.AccountName = acc.AccountName;
                        AccountBalance.StartingBalance = invAmount;
                        AccountBalance.CreditAmount = acc.Transactions.Sum(x => x.CreditAmount);
                        AccountBalance.DebitAmount = acc.Transactions.Sum(x => x.DebitAmount);
                        AccountBalance.NetMovement = AccountBalance.DebitAmount - AccountBalance.CreditAmount;
                        AccountBalance.EndingBalance = AccountBalance.StartingBalance + AccountBalance.NetMovement;
                        accountMasterDto.BankAccount.Add(AccountBalance);
                    }
                }
                AccountBalanceAccountDetailDto TotalAccountBalance = new AccountBalanceAccountDetailDto();
                TotalAccountBalance.AccountName = "Total " + item.AccountMasterName;
                TotalAccountBalance.StartingBalance = accountMasterDto.BankAccount.Sum(x => x.StartingBalance);
                TotalAccountBalance.CreditAmount = accountMasterDto.BankAccount.Sum(x => x.CreditAmount);
                TotalAccountBalance.DebitAmount = accountMasterDto.BankAccount.Sum(x => x.DebitAmount);
                TotalAccountBalance.NetMovement = accountMasterDto.BankAccount.Sum(x => x.NetMovement);
                TotalAccountBalance.EndingBalance = accountMasterDto.BankAccount.Sum(x => x.EndingBalance);
                accountMasterDto.BankAccount.Add(TotalAccountBalance);
                accountBalanceList.Add(accountMasterDto);
            }

            accountTotalBalanceDtoObj.accountBalanceReportDtoList = accountBalanceList;
            foreach (var totalAcc in accountBalanceList)
            {
                accountTotalBalanceDtoObj.TotalCreditAmount += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.CreditAmount);
                accountTotalBalanceDtoObj.TotalDebitAmount += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.DebitAmount);
            }

            return accountTotalBalanceDtoObj;
        }
        public async Task<ProfitAndLossMainDto> GetProfitAndLossDetailsReportAsync(ProfitAndLossModel model)
        {
            var data = await _reportRepository.GetProfitAndLossDetailsReportAsync();

            List<ProfitAndLossDetailsDto> profitAndLossList = new List<ProfitAndLossDetailsDto>();
            ProfitAndLossMainDto mainProfitAndLossDtoObj = new ProfitAndLossMainDto();

            foreach (var item in data)
            {
                ProfitAndLossDetailsDto profitAndLossMasterDto = new ProfitAndLossDetailsDto();
                profitAndLossMasterDto.Id = item.Id;
                profitAndLossMasterDto.AccountMasterName = item.AccountMasterName;
                profitAndLossMasterDto.BankAccount = new List<ProfitAndLossDetailsReportDto>();
                foreach (var accType in item.AccountTypes)
                {

                    foreach (var acc in accType.BankAccount)
                    {
                        acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate)).ToList();
                        if (model.ReportType == 0)
                        {
                            acc.Transactions = acc.Transactions.Where(p => p.Status == Constants.TransactionStatus.Paid).ToList();
                        }

                        ProfitAndLossDetailsReportDto AccountBalance = new ProfitAndLossDetailsReportDto();
                        AccountBalance.Id = acc.Id;
                        AccountBalance.AccountName = acc.AccountName;
                        if (accType.COA_AccountMasterId == 3)
                        {
                            AccountBalance.IncomeDebitAmount = acc.Transactions.Sum(x => x.DebitAmount);
                        }
                        else if(accType.COA_AccountMasterId == 4)
                        {
                            AccountBalance.OperatingExpensesCreditAmount = acc.Transactions.Sum(x => x.CreditAmount);
                        }
                        profitAndLossMasterDto.BankAccount.Add(AccountBalance);
                    }
                }
                ProfitAndLossDetailsReportDto TotalAccountBalance = new ProfitAndLossDetailsReportDto();
                TotalAccountBalance.AccountName = "Total " + item.AccountMasterName;
                TotalAccountBalance.IncomeDebitAmount = profitAndLossMasterDto.BankAccount.Sum(x => x.IncomeDebitAmount);
                TotalAccountBalance.OperatingExpensesCreditAmount = profitAndLossMasterDto.BankAccount.Sum(x => x.OperatingExpensesCreditAmount);
                profitAndLossMasterDto.BankAccount.Add(TotalAccountBalance);
                profitAndLossList.Add(profitAndLossMasterDto);
            }

            mainProfitAndLossDtoObj.mainProfitAndLossDetailsList = profitAndLossList;
            foreach (var totalAcc in profitAndLossList)
            {
                mainProfitAndLossDtoObj.GrossProfit += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeDebitAmount);
                mainProfitAndLossDtoObj.NetProfit += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeDebitAmount - x.OperatingExpensesCreditAmount);
            }

            return mainProfitAndLossDtoObj;
        }
        public async Task<List<BalanceSheetReportDto>> GetBalanceSheetReportAsync(BalanceSheetModel model)
        {
            var data = await _reportRepository.GetBalanceSheetReportAsync();

            List<BalanceSheetReportDto> accountDetailDto = new List<BalanceSheetReportDto>();
            foreach (var item in data)
            {
                BalanceSheetReportDto accountMasterDto = new BalanceSheetReportDto();
                accountMasterDto.Id = item.Id;
                accountMasterDto.AccountMasterName = item.AccountMasterName;
                accountMasterDto.BankAccount = new List<BalanceSheetDetailsReportDto>();
                foreach (var accType in item.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                        if (model.ReportType == 0)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate <= model.AsOfDate)).ToList();
                        }
                        else if (model.ReportType == 1)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate <= model.AsOfDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
                        }
                        if(model.Tab == 0)
                        {
                            BalanceSheetDetailsReportDto trialAcc = new BalanceSheetDetailsReportDto();
                            trialAcc.Id = acc.Id;
                            trialAcc.AccountName = "Total " + acc.AccountName;
                            trialAcc.Amount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                            accountMasterDto.BankAccount.Add(trialAcc);
                        }
                        else
                        {
                            BalanceSheetDetailsReportDto trialAcc = new BalanceSheetDetailsReportDto();
                            trialAcc.Id = acc.Id;
                            trialAcc.AccountName = acc.AccountName;
                            trialAcc.Amount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                            accountMasterDto.BankAccount.Add(trialAcc);

                            trialAcc = new BalanceSheetDetailsReportDto();
                            trialAcc.AccountName = "Total " + acc.AccountName;
                            trialAcc.Amount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                            accountMasterDto.BankAccount.Add(trialAcc);
                        }
                    }
                }
                BalanceSheetDetailsReportDto trialTotalAcc = new BalanceSheetDetailsReportDto();
                trialTotalAcc.AccountName = "Total " + item.AccountMasterName;
                trialTotalAcc.Amount = accountMasterDto.BankAccount.Where(x => x.Id != 0).Sum(x => x.Amount);
                accountMasterDto.BankAccount.Add(trialTotalAcc);
                accountDetailDto.Add(accountMasterDto);
            }
            return accountDetailDto;
        }

        public async Task<AccountTransactionReportMasterDto> GetAccountTransaction(AccountTransactionReportModel model)
        {
            var data = await _reportRepository.GetCOADetailAsyncForAccountTransactionReport();

            AccountTransactionReportMasterDto accountDetailDtoMasterList = new AccountTransactionReportMasterDto();
            accountDetailDtoMasterList.BankList = new List<AccountTransactionReportDto>();
            foreach (var item in data)
            {
             //  List<AccountTransactionReportDto> accountDetailDtoList = new List<AccountTransactionReportDto>();
              
                //accountMasterDto.Id = item.Id;
                //accountMasterDto.AccountMasterName = item.AccountMasterName;
                //accountMasterDto.BankAccount = new List<TrialBalanceAccountDetailDto>();
                foreach (var accType in item.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                        AccountTransactionReportDto accountDetailDto = new AccountTransactionReportDto();
                        accountDetailDto.Transactions = new List<AccountTransactionReportDetailDto>();
                        accountDetailDto.AccountMasterName = item.AccountMasterName;
                        accountDetailDto.AccountTypeName = accType.AccountTypeName;
                        accountDetailDto.AccountName = acc.AccountName;
                        var transListForStartingbalance = acc.Transactions.Where(p => (p.TransactionDate <= model.FromDate)).ToList();
                        var creditAmount = transListForStartingbalance.Sum(x => x.CreditAmount);
                        var debitAmount = transListForStartingbalance.Sum(x => x.DebitAmount);
                        accountDetailDto.StartingBalance = debitAmount - creditAmount;
                        if (model.AccountId > 0)
                        {
                            acc.Transactions = acc.Transactions.Where(x => x.BankAccountId == model.AccountId).ToList();
                        }
                        if (model.ContactId > 0)
                        {
                            acc.Transactions = acc.Transactions.Where(x => x.ContactId == model.ContactId && x.ContactType == model.ContactType).ToList();
                        }

                        if (model.ReportType == 0)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.FromDate && p.TransactionDate <= model.ToDate)).ToList();
                        }
                        else if (model.ReportType == 1)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.FromDate && p.TransactionDate <= model.ToDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
                        }

                        foreach (var trans in acc.Transactions)
                        {
                            AccountTransactionReportDetailDto accountMasterDto = new AccountTransactionReportDetailDto();
                            accountMasterDto.Id = trans.TransactionId ?? 0;
                            accountMasterDto.CreditAmount = trans.CreditAmount;
                            accountMasterDto.TransactionDate = trans.TransactionDate;
                            accountMasterDto.TransactionType = trans.TransactionType;
                            accountMasterDto.DebitAmount = trans.DebitAmount;
                            accountDetailDto.Transactions.Add(accountMasterDto);
                        }
                        decimal openingBal = accountDetailDto.StartingBalance;
                        foreach(var setBal in accountDetailDto.Transactions)
                        {
                            setBal.Balance = openingBal + setBal.DebitAmount - setBal.CreditAmount;
                            openingBal = setBal.Balance;
                        }
                        accountDetailDto.BalanceChange = openingBal;
                        accountDetailDto.TotalAndEndingBalance = openingBal;
                        accountDetailDto.TotalAndEndingBalanceCreditAmount = accountDetailDto.Transactions.Sum(x => x.CreditAmount);
                        accountDetailDto.TotalAndEndingBalanceDebitAmount = accountDetailDto.Transactions.Sum(x => x.DebitAmount);
                        accountDetailDtoMasterList.BankList.Add(accountDetailDto);
                        //AccountTransactionReportDetailDto totalEndingBalDto = new AccountTransactionReportDetailDto();
                        //totalEndingBalDto.Id =  0;
                        //accountMasterDto.CreditAmount = trans.CreditAmount;
                        //accountMasterDto.TransactionDate = trans.TransactionDate;
                        //accountMasterDto.TransactionType = trans.TransactionType;
                        //accountMasterDto.DebitAmount = trans.DebitAmount;
                        //accountDetailDto.Transactions.Add(accountMasterDto);
                    }
                }
               // accountDetailDtoMasterList.BankList.Add(accountDetailDtoList);
            }
            return accountDetailDtoMasterList;
        }

    }
}
