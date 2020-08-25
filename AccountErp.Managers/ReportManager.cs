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
           // var dataForAmount = await _reportRepository.GetProfitAndLossDetailsForAmount();
            List<ProfitAndLossDetailsDto> profitAndLossList = new List<ProfitAndLossDetailsDto>();
            ProfitAndLossMainDto mainProfitAndLossDtoObj = new ProfitAndLossMainDto();
            ProfitAndLossDetailsDto profitAndLossDto = new ProfitAndLossDetailsDto();
            profitAndLossDto.IncomeAccount = new List<ProfitAndLossDetailsReportDto>();
            profitAndLossDto.ExpenseAccount = new List<ProfitAndLossDetailsReportDto>();
            decimal totalIncome = 0;
            decimal totalExpense = 0;
            decimal netProfit = 0;

            foreach (var item in data)
            {
                foreach(var acctype in item.AccountTypes)
                {
                    foreach (var acc in acctype.BankAccount)
                    {
                        if (model.ReportType == 0)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate)).ToList();
                        }
                        else if (model.ReportType == 1)
                        {
                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
                        }

                        ProfitAndLossDetailsReportDto AccountBalance = new ProfitAndLossDetailsReportDto();
                        AccountBalance.Id = acc.Id;
                        AccountBalance.AccountName = acc.AccountName;
                        decimal totalAmount = 0;
                        totalAmount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                        AccountBalance.Amount = Math.Abs(totalAmount);

                        if(totalAmount > 0)
                        {
                            totalIncome += totalAmount;
                            profitAndLossDto.IncomeAccount.Add(AccountBalance);
                        }
                        else
                        {
                            totalExpense += Math.Abs(totalAmount);
                            profitAndLossDto.ExpenseAccount.Add(AccountBalance);
                        }
                    }
                }
            }

            profitAndLossDto.Netprofit = profitAndLossDto.IncomeAccount.Sum(x => x.Amount) - profitAndLossDto.ExpenseAccount.Sum(x => x.Amount);

            ProfitAndLossDetailsReportDto dtoForTotalIncome = new ProfitAndLossDetailsReportDto();
            dtoForTotalIncome.Id = 0;
            dtoForTotalIncome.AccountName = "Total Income";
            dtoForTotalIncome.Amount = profitAndLossDto.IncomeAccount.Sum(x => x.Amount);
            profitAndLossDto.IncomeAccount.Add(dtoForTotalIncome);

            ProfitAndLossDetailsReportDto dtoForTotalExpense = new ProfitAndLossDetailsReportDto();
            dtoForTotalExpense.Id = 0;
            dtoForTotalExpense.AccountName = "Total Expense";
            dtoForTotalExpense.Amount = profitAndLossDto.ExpenseAccount.Sum(x => x.Amount);
            profitAndLossDto.ExpenseAccount.Add(dtoForTotalExpense);

           

            mainProfitAndLossDtoObj.Income = totalIncome;
            mainProfitAndLossDtoObj.OperatingExpenses = totalExpense;
            mainProfitAndLossDtoObj.NetProfit = totalIncome - totalExpense;
            mainProfitAndLossDtoObj.mainProfitAndLossDetailsList = profitAndLossDto;
            return mainProfitAndLossDtoObj;
        }

        //public async Task<ProfitAndLossMainDto> GetProfitAndLossDetailsReportAsync(ProfitAndLossModel model)
        //{
        //    var data = await _reportRepository.GetProfitAndLossDetailsReportAsync();
        //    var dataForAmount = await _reportRepository.GetProfitAndLossDetailsForAmount();
        //    List<ProfitAndLossDetailsDto> profitAndLossList = new List<ProfitAndLossDetailsDto>();
        //    ProfitAndLossMainDto mainProfitAndLossDtoObj = new ProfitAndLossMainDto();
        //    ProfitAndLossDetailsDto profitAndLossMasterDto = new ProfitAndLossDetailsDto();
        //    profitAndLossMasterDto.BankAccount = new List<ProfitAndLossDetailsReportDto>();
        //    foreach (var bank in dataForAmount)
        //    {


        //        ProfitAndLossDetailsReportDto AccountBalance = new ProfitAndLossDetailsReportDto();
        //        AccountBalance.Id = bank.Id;
        //        AccountBalance.IncomeCreditAmount = bank.CreditAmount;
        //        AccountBalance.OperatingExpensesDebitAmount = bank.DebitAmount;
        //        profitAndLossMasterDto.BankAccount.Add(AccountBalance);

        //        if(bank.CreditAmount != 0)
        //        {
        //            foreach (var item in data)
        //            {
        //                profitAndLossMasterDto = new ProfitAndLossDetailsDto();
        //                profitAndLossMasterDto.Id = item.Id;
        //                profitAndLossMasterDto.AccountMasterName = item.AccountMasterName;
        //                profitAndLossMasterDto.BankAccount = new List<ProfitAndLossDetailsReportDto>();
        //                foreach (var accType in item.AccountTypes)
        //                {

        //                    foreach (var acc in accType.BankAccount)
        //                    {
        //                        if (model.ReportType == 0)
        //                        {
        //                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate)).ToList();
        //                        }
        //                        else if (model.ReportType == 1)
        //                        {
        //                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
        //                        }

        //                        AccountBalance = new ProfitAndLossDetailsReportDto();
        //                        AccountBalance.Id = acc.Id;
        //                        AccountBalance.AccountName = acc.AccountName;
        //                        profitAndLossMasterDto.BankAccount.Add(AccountBalance);
        //                    }
        //                }
        //            }
        //        }else if(bank.DebitAmount != 0)
        //        {
        //            foreach (var item in data)
        //            {
        //                profitAndLossMasterDto = new ProfitAndLossDetailsDto();
        //                profitAndLossMasterDto.Id = item.Id;
        //                profitAndLossMasterDto.AccountMasterName = item.AccountMasterName;
        //                profitAndLossMasterDto.BankAccount = new List<ProfitAndLossDetailsReportDto>();
        //                foreach (var accType in item.AccountTypes)
        //                {

        //                    foreach (var acc in accType.BankAccount)
        //                    {
        //                        if (model.ReportType == 0)
        //                        {
        //                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate)).ToList();
        //                        }
        //                        else if (model.ReportType == 1)
        //                        {
        //                            acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
        //                        }

        //                        AccountBalance = new ProfitAndLossDetailsReportDto();
        //                        AccountBalance.Id = acc.Id;
        //                        AccountBalance.AccountName = acc.AccountName;
        //                        profitAndLossMasterDto.BankAccount.Add(AccountBalance);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    profitAndLossList.Add(profitAndLossMasterDto);

        //    /*foreach (var item in data)
        //    {
        //        ProfitAndLossDetailsDto profitAndLossMasterDto = new ProfitAndLossDetailsDto();
        //        profitAndLossMasterDto.Id = item.Id;
        //        profitAndLossMasterDto.AccountMasterName = item.AccountMasterName;
        //        profitAndLossMasterDto.BankAccount = new List<ProfitAndLossDetailsReportDto>();
        //        foreach (var accType in item.AccountTypes)
        //        {

        //            foreach (var acc in accType.BankAccount)
        //            {
        //                if (model.ReportType == 0)
        //                {
        //                    acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate)).ToList();
        //                }
        //                else if (model.ReportType == 1)
        //                {
        //                    acc.Transactions = acc.Transactions.Where(p => (p.TransactionDate >= model.StartDate && p.TransactionDate <= model.EndDate && p.Status == Constants.TransactionStatus.Paid)).ToList();
        //                }

        //                ProfitAndLossDetailsReportDto AccountBalance = new ProfitAndLossDetailsReportDto();
        //                AccountBalance.Id = acc.Id;
        //                AccountBalance.AccountName = acc.AccountName;
        //                AccountBalance.IncomeCreditAmount = acc.Transactions.Sum(x => x.DebitAmount);
        //                AccountBalance.OperatingExpensesDebitAmount = acc.Transactions.Sum(x => x.CreditAmount);

        //                *//*if (accType.COA_AccountMasterId == 3)
        //                {
        //                    AccountBalance.IncomeDebitAmount = acc.Transactions.Sum(x => x.DebitAmount);
        //                }
        //                else if (accType.COA_AccountMasterId == 4)
        //                {
        //                    AccountBalance.OperatingExpensesCreditAmount = acc.Transactions.Sum(x => x.CreditAmount);
        //                }*//*
        //                profitAndLossMasterDto.BankAccount.Add(AccountBalance);
        //            }
        //        }
        //        ProfitAndLossDetailsReportDto TotalAccountBalance = new ProfitAndLossDetailsReportDto();
        //        TotalAccountBalance.AccountName = "Total " + item.AccountMasterName;

        //        TotalAccountBalance.IncomeCreditAmount = profitAndLossMasterDto.BankAccount.Sum(x => x.IncomeCreditAmount);
        //        TotalAccountBalance.OperatingExpensesDebitAmount = profitAndLossMasterDto.BankAccount.Sum(x => x.OperatingExpensesDebitAmount);
        //        if(profitAndLossMasterDto.AccountMasterName == "Income")
        //        {
        //            profitAndLossMasterDto.GrossProfit += profitAndLossMasterDto.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeCreditAmount);
        //        }
        //        profitAndLossMasterDto.BankAccount.Add(TotalAccountBalance);
        //        profitAndLossList.Add(profitAndLossMasterDto);
        //    }*/



        //    mainProfitAndLossDtoObj.mainProfitAndLossDetailsList = profitAndLossList;
        //    foreach (var totalAcc in profitAndLossList)
        //    {
        //        if (model.TabId == 1)
        //        {
        //            mainProfitAndLossDtoObj.GrossProfit += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeCreditAmount);
        //            mainProfitAndLossDtoObj.NetProfit += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeCreditAmount - x.OperatingExpensesDebitAmount);
        //        }
        //        else
        //        {
        //            Decimal Amount = 0;
        //            Amount = totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeCreditAmount - x.OperatingExpensesDebitAmount);
        //            if(Amount > 0)
        //            {
        //                mainProfitAndLossDtoObj.Income += Amount;
        //            }
        //            else
        //            {
        //                mainProfitAndLossDtoObj.OperatingExpenses += Amount;
        //            }
        //            mainProfitAndLossDtoObj.NetProfit += mainProfitAndLossDtoObj.Income - mainProfitAndLossDtoObj.OperatingExpenses; 

        //           /* mainProfitAndLossDtoObj.Income += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeDebitAmount);
        //            mainProfitAndLossDtoObj.OperatingExpenses += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.OperatingExpensesCreditAmount);
        //            mainProfitAndLossDtoObj.GrossProfit += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeDebitAmount);
        //            mainProfitAndLossDtoObj.NetProfit += totalAcc.BankAccount.Where(x => x.Id != 0).Sum(x => x.IncomeDebitAmount - x.OperatingExpensesCreditAmount);*/
        //        }

        //    }

        //    return mainProfitAndLossDtoObj;
        //}
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
                        if (model.Tab == 0)
                        {
                            BalanceSheetDetailsReportDto BalanceSheetAcc = new BalanceSheetDetailsReportDto();
                            BalanceSheetAcc.Id = acc.Id;
                            BalanceSheetAcc.AccountName = "Total " + acc.AccountName;
                            BalanceSheetAcc.Amount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                            accountMasterDto.BankAccount.Add(BalanceSheetAcc);
                        }
                        else
                        {
                            BalanceSheetDetailsReportDto BalanceSheetAcc = new BalanceSheetDetailsReportDto();
                            BalanceSheetAcc.Id = acc.Id;
                            BalanceSheetAcc.AccountName = acc.AccountName;
                            BalanceSheetAcc.Amount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                            accountMasterDto.BankAccount.Add(BalanceSheetAcc);

                            BalanceSheetAcc = new BalanceSheetDetailsReportDto();
                            BalanceSheetAcc.AccountName = "Total " + acc.AccountName;
                            BalanceSheetAcc.Amount = acc.Transactions.Sum(x => x.DebitAmount - x.CreditAmount);
                            accountMasterDto.BankAccount.Add(BalanceSheetAcc);
                        }
                    }
                }
                BalanceSheetDetailsReportDto balanceSheetTotalAcc = new BalanceSheetDetailsReportDto();
                balanceSheetTotalAcc.AccountName = "Total " + item.AccountMasterName;
                balanceSheetTotalAcc.Amount = accountMasterDto.BankAccount.Where(x => x.Id != 0).Sum(x => x.Amount);
                accountMasterDto.BankAccount.Add(balanceSheetTotalAcc);
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

        public async Task<CashFlowReportDto> GetCashFlowReportForSummaryAsync(CashFlowModel model)
        {
            var data = await _reportRepository.GetCashFlowReportAsync();
            
            CashFlowReportDto accountDetailDto = new CashFlowReportDto();
            accountDetailDto.OperatingActivities = new List<CashFlowSummaryReportDto>();
            accountDetailDto.Overview = new List<CashFlowSummaryReportDto>();

            //For Sales
            decimal salesAmount = 0;
            decimal purchaseAmount = 0;
            decimal salesTaxAmount = 0;
            decimal inflowAmount = 0;
            decimal outflowAmount = 0;
            var dataForIncome = data.Where(x => x.Id == 3);
            foreach (var accMaster in dataForIncome)
            {
                CashFlowSummaryReportDto cashFlowDetailsReportDto = new CashFlowSummaryReportDto();
                cashFlowDetailsReportDto.AccountName = "Sales";
                decimal debitAmount = 0;
                decimal creditAmount = 0;
                foreach (var accType in accMaster.AccountTypes)
                {
                   
                    foreach (var acc in accType.BankAccount)
                    {
                        debitAmount += acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                        creditAmount += acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);
                    }
                }
                if (debitAmount > 0)
                {
                    cashFlowDetailsReportDto.Amount = debitAmount - creditAmount;
                }
                else
                {
                    cashFlowDetailsReportDto.Amount = creditAmount;
                }
                salesAmount = cashFlowDetailsReportDto.Amount;
                inflowAmount += salesAmount;
                accountDetailDto.OperatingActivities.Add(cashFlowDetailsReportDto);
            }

            //For Purchase
            var dataForPurchase = data.Where(x => x.Id == 4);
            foreach (var accMaster in dataForPurchase)
            {
                CashFlowSummaryReportDto cashFlowDetailsReportDto = new CashFlowSummaryReportDto();
                cashFlowDetailsReportDto.AccountName = "Purchase";
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                        var debitAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                        var creditAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);

                        cashFlowDetailsReportDto.Amount += debitAmount - creditAmount;
                    }
                }
                purchaseAmount = cashFlowDetailsReportDto.Amount;
                outflowAmount += purchaseAmount;
                accountDetailDto.OperatingActivities.Add(cashFlowDetailsReportDto);
            }

            //For Sales Tax
            var dataForTax = data.Where(x => x.Id == 2);
            foreach (var accMaster in dataForTax)
            {
                CashFlowSummaryReportDto cashFlowDetailsReportDto = new CashFlowSummaryReportDto();
                cashFlowDetailsReportDto.AccountName = "SalesTax";
                foreach (var accType in accMaster.AccountTypes)
                {
                    if(accType.Id == 9)
                    {
                        decimal debitAmount = 0;
                        decimal creditAmount = 0;
                        foreach (var acc in accType.BankAccount)
                        {
                             debitAmount += acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                             creditAmount += acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);

                           
                        }
                        inflowAmount += debitAmount;
                        outflowAmount += creditAmount;
                        cashFlowDetailsReportDto.Amount = Math.Abs(debitAmount) - Math.Abs(creditAmount);
                    }
                }
                salesTaxAmount = cashFlowDetailsReportDto.Amount;
                accountDetailDto.OperatingActivities.Add(cashFlowDetailsReportDto);
            }

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForTotal = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForTotal.AccountName = "Net Cash From Operating Activiteis";
            cashFlowDetailsReportDtoForTotal.Amount = salesAmount - purchaseAmount + salesTaxAmount;
            accountDetailDto.OperatingActivities.Add(cashFlowDetailsReportDtoForTotal);

            var dataForAssets = data.Where(x => x.Id == 1);
            decimal debitAmountForStartingBal = 0;
            decimal creditAmountForStartingBal = 0;
            decimal debitAmountForEndingBal = 0;
            decimal creditAmountForEndingBal = 0;
            //For Starting Balance
            foreach (var accMaster in dataForAssets)
            {
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {

                        CashFlowSummaryReportDto cashFlowDetailsReportDtoForAssets = new CashFlowSummaryReportDto();
                        cashFlowDetailsReportDtoForAssets.AccountName = acc.AccountName;
                        debitAmountForStartingBal += acc.Transactions.Where(y => y.TransactionDate <= model.StartDate).Sum(x => x.DebitAmount);
                        creditAmountForStartingBal = acc.Transactions.Where(y => y.TransactionDate <= model.StartDate).Sum(x => x.CreditAmount);
                    }
                }

            }

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForTotalStarting = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForTotalStarting.AccountName = "Total Starting Balance";
            cashFlowDetailsReportDtoForTotalStarting.Amount = debitAmountForStartingBal - creditAmountForStartingBal;
            accountDetailDto.Overview.Add(cashFlowDetailsReportDtoForTotalStarting);

        
            CashFlowSummaryReportDto cashFlowDetailsReportDtoForInflow = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForInflow.AccountName = "Gross Cash Inflow";
            cashFlowDetailsReportDtoForInflow.Amount = inflowAmount;
            accountDetailDto.Overview.Add(cashFlowDetailsReportDtoForInflow);

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForOutflow = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForOutflow.AccountName = "Gross Cash Outflow";
            cashFlowDetailsReportDtoForOutflow.Amount = outflowAmount;
            accountDetailDto.Overview.Add(cashFlowDetailsReportDtoForOutflow);

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForNetCash = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForNetCash.AccountName = "Net Cash Change";
            cashFlowDetailsReportDtoForNetCash.Amount = inflowAmount - outflowAmount;
            accountDetailDto.Overview.Add(cashFlowDetailsReportDtoForNetCash);

            //For Ending Balance
            foreach (var accMaster in dataForAssets)
            {
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {

                        CashFlowSummaryReportDto cashFlowDetailsReportDtoForAssets = new CashFlowSummaryReportDto();
                        cashFlowDetailsReportDtoForAssets.AccountName = acc.AccountName;
                        debitAmountForEndingBal = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Pending && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                        creditAmountForEndingBal = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Pending && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);
                    }
                }

            }

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForTotalEnding = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForTotalEnding.AccountName = "Total Ending Balance";
            cashFlowDetailsReportDtoForTotalEnding.Amount = debitAmountForEndingBal - creditAmountForEndingBal;
            accountDetailDto.Overview.Add(cashFlowDetailsReportDtoForTotalEnding);


            return accountDetailDto;
        }

        public async Task<CashFlowMasterDetailDto> GetCashFlowReportForDetailAsync(CashFlowModel model)
        {
            var data = await _reportRepository.GetCashFlowReportAsync();

            CashFlowMasterDetailDto accountDetailDto = new CashFlowMasterDetailDto();
            accountDetailDto.OperatingActivities = new List<CashFlowDetailsReportDto>();
            accountDetailDto.Overview = new CashFlowDetailOverviewDto();
            accountDetailDto.Overview.GrossDetail = new List<CashFlowSummaryReportDto>();
            accountDetailDto.Overview.StartingBalance = new List<CashFlowSummaryReportDto>();
            accountDetailDto.Overview.EndingBalance = new List<CashFlowSummaryReportDto>();

            //For Sales

            var dataForIncome = data.Where(x => x.Id == 3);

            CashFlowDetailsReportDto cashFlowDetailsReportDto = new CashFlowDetailsReportDto();

            decimal inflowAmount = 0;
            decimal outflowAmount = 0;

            foreach (var accMaster in dataForIncome)
            {
                cashFlowDetailsReportDto.Sales = new List<CashFlowSummaryReportDto>();
         
                decimal debitAmount = 0;
                decimal creditAmount = 0;
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                        CashFlowSummaryReportDto cashFlowSumarryReportDto = new CashFlowSummaryReportDto();
                        cashFlowSumarryReportDto.AccountName = acc.AccountName;
                        debitAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                        creditAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);
                        if (debitAmount > 0)
                        {
                            cashFlowSumarryReportDto.Amount = debitAmount - creditAmount;
                        }
                        else
                        {
                            cashFlowSumarryReportDto.Amount = creditAmount;
                        }
                        inflowAmount += cashFlowSumarryReportDto.Amount;
                        cashFlowDetailsReportDto.Sales.Add(cashFlowSumarryReportDto);
                      
                    }

                }
            }

            CashFlowSummaryReportDto cashFlowSumarryReportTotalSalesDto = new CashFlowSummaryReportDto();
            cashFlowSumarryReportTotalSalesDto.AccountName = "Total Sales";
            cashFlowSumarryReportTotalSalesDto.Amount = cashFlowDetailsReportDto.Sales.Sum(x => x.Amount);
            cashFlowDetailsReportDto.Sales.Add(cashFlowSumarryReportTotalSalesDto);

            //For Purchase
            var dataForPurchase = data.Where(x => x.Id == 4);
            foreach (var accMaster in dataForPurchase)
            {
           
                cashFlowDetailsReportDto.Purchase = new List<CashFlowSummaryReportDto>();
              
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {
                       
                        CashFlowSummaryReportDto cashFlowSumarryReportDto = new CashFlowSummaryReportDto();
                        cashFlowSumarryReportDto.AccountName = acc.AccountName;
                        var debitAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                        var creditAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);

                        cashFlowSumarryReportDto.Amount += debitAmount - creditAmount;
                        outflowAmount += cashFlowSumarryReportDto.Amount;
                        cashFlowDetailsReportDto.Purchase.Add(cashFlowSumarryReportDto);
                    }
                }
             
            }

            CashFlowSummaryReportDto cashFlowSumarryReportTotalPurchaseDto = new CashFlowSummaryReportDto();
            cashFlowSumarryReportTotalPurchaseDto.AccountName = "Total Purchase";
            cashFlowSumarryReportTotalPurchaseDto.Amount = cashFlowDetailsReportDto.Purchase.Sum(x => x.Amount);

            cashFlowDetailsReportDto.Purchase.Add(cashFlowSumarryReportTotalPurchaseDto);


            //For Sales Tax
            var dataForTax = data.Where(x => x.Id == 2); 
            decimal debitAmountForTax = 0;
            decimal creditAmountForTax = 0;
            foreach (var accMaster in dataForTax)
            {
               
                cashFlowDetailsReportDto.SalesTax = new List<CashFlowSummaryReportDto>();
                foreach (var accType in accMaster.AccountTypes)
                {
                    if (accType.Id == 9)
                    {
                        foreach (var acc in accType.BankAccount)
                        {
                          
                            CashFlowSummaryReportDto cashFlowSumarryReportDtoForProceed = new CashFlowSummaryReportDto();
                            cashFlowSumarryReportDtoForProceed.AccountName ="Proceed " + acc.AccountName;
                            var debitAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);

                            cashFlowSumarryReportDtoForProceed.Amount = debitAmount;
                            debitAmountForTax += debitAmount;
                            inflowAmount += debitAmount;
                            cashFlowDetailsReportDto.SalesTax.Add(cashFlowSumarryReportDtoForProceed);

                            CashFlowSummaryReportDto cashFlowSumarryReportDtoForPayment = new CashFlowSummaryReportDto();
                            cashFlowSumarryReportDtoForPayment.AccountName = "Payment " + acc.AccountName;
                          
                            var creditAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Paid && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);

                            cashFlowSumarryReportDtoForPayment.Amount =  creditAmount;
                            creditAmountForTax += creditAmount;
                            outflowAmount += creditAmount;
                            cashFlowDetailsReportDto.SalesTax.Add(cashFlowSumarryReportDtoForPayment);
                        }
                    }
                }
              
            }

            CashFlowSummaryReportDto cashFlowSumarryReportTotalSalesTaxDto = new CashFlowSummaryReportDto();
            cashFlowSumarryReportTotalSalesTaxDto.AccountName = "Total Sales Tax";
            cashFlowSumarryReportTotalSalesTaxDto.Amount = debitAmountForTax - creditAmountForTax;
            cashFlowDetailsReportDto.SalesTax.Add(cashFlowSumarryReportTotalSalesTaxDto);
            accountDetailDto.OperatingActivities.Add(cashFlowDetailsReportDto);

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForInflow = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForInflow.AccountName = "Gross Cash Inflow";
            cashFlowDetailsReportDtoForInflow.Amount = inflowAmount;
            accountDetailDto.Overview.GrossDetail.Add(cashFlowDetailsReportDtoForInflow);

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForOutflow = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForOutflow.AccountName = "Gross Cash Outflow";
            cashFlowDetailsReportDtoForOutflow.Amount = outflowAmount;
            accountDetailDto.Overview.GrossDetail.Add(cashFlowDetailsReportDtoForOutflow);

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForNetCash = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForNetCash.AccountName = "Net Cash Change";
            cashFlowDetailsReportDtoForNetCash.Amount = inflowAmount - outflowAmount;
            accountDetailDto.Overview.GrossDetail.Add(cashFlowDetailsReportDtoForNetCash);

            var dataForAssets = data.Where(x => x.Id == 1);
            //decimal debitAmountForTax = 0;
            //decimal creditAmountForTax = 0;
            //For Starting Balance
            foreach (var accMaster in dataForAssets)
            {
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {

                        CashFlowSummaryReportDto cashFlowDetailsReportDtoForAssets = new CashFlowSummaryReportDto();
                        cashFlowDetailsReportDtoForAssets.AccountName = acc.AccountName;
                        var debitAmount = acc.Transactions.Where(y =>  y.TransactionDate <= model.StartDate).Sum(x => x.DebitAmount);
                        var creditAmount = acc.Transactions.Where(y => y.TransactionDate <= model.StartDate).Sum(x => x.CreditAmount);
                        cashFlowDetailsReportDtoForAssets.Amount = debitAmount - creditAmount;
                        accountDetailDto.Overview.StartingBalance.Add(cashFlowDetailsReportDtoForAssets);
                    }
                }

            }

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForTotalStarting = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForTotalStarting.AccountName = "Total Starting Balance";
            cashFlowDetailsReportDtoForTotalStarting.Amount = accountDetailDto.Overview.StartingBalance.Sum(x => x.Amount);
            accountDetailDto.Overview.StartingBalance.Add(cashFlowDetailsReportDtoForTotalStarting);

            //For Ending Balance
            foreach (var accMaster in dataForAssets)
            {
                foreach (var accType in accMaster.AccountTypes)
                {
                    foreach (var acc in accType.BankAccount)
                    {

                        CashFlowSummaryReportDto cashFlowDetailsReportDtoForAssets = new CashFlowSummaryReportDto();
                        cashFlowDetailsReportDtoForAssets.AccountName = acc.AccountName;
                        var debitAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Pending && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.DebitAmount);
                        var creditAmount = acc.Transactions.Where(y => y.Status == Constants.TransactionStatus.Pending && y.ModifyDate >= model.StartDate && y.ModifyDate <= model.EndDate).Sum(x => x.CreditAmount);
                        cashFlowDetailsReportDtoForAssets.Amount = debitAmount - creditAmount;
                        accountDetailDto.Overview.EndingBalance.Add(cashFlowDetailsReportDtoForAssets);
                    }
                }

            }

            CashFlowSummaryReportDto cashFlowDetailsReportDtoForTotalEnding = new CashFlowSummaryReportDto();
            cashFlowDetailsReportDtoForTotalEnding.AccountName = "Total Ending Balance";
            cashFlowDetailsReportDtoForTotalEnding.Amount = accountDetailDto.Overview.EndingBalance.Sum(x => x.Amount);
            accountDetailDto.Overview.EndingBalance.Add(cashFlowDetailsReportDtoForTotalEnding);

            return accountDetailDto;
        }


    }
}
