using AccountErp.Entities;
using AccountErp.Models.Bill;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace AccountErp.Factories
{
    public class TransactionFactory
    {
        public static Transaction CreateByInvoice(Invoice entity)
        {
            var transaction = new Transaction
            {
                TransactionId = entity.Id,
                CompanyId = null,
                TransactionTypeId = Constants.TransactionType.InvoicePayment,
                TransactionDate = Utility.GetDateTime(),
                TransactionNumber = entity.InvoiceNumber,
                ContactType = Constants.ContactType.Customer,
                ContactId = entity.CustomerId,
                BankAccountId = 1,
                DebitAmount = entity.TotalAmount,
                CreditAmount = 0,
                CreationDate = Utility.GetDateTime(),
                ModifyDate = null
            };

            return transaction;
        }

        public static Transaction CreateByInvoiceItemsAndTax(Invoice entity, int AccId, decimal? amount)
        {
            var transaction = new Transaction
            {
                TransactionId = entity.Id,
                CompanyId = null,
                TransactionTypeId = Constants.TransactionType.InvoicePayment,
                TransactionDate = Utility.GetDateTime(),
                TransactionNumber = entity.InvoiceNumber,
                ContactType = Constants.ContactType.Customer,
                ContactId = entity.CustomerId,
                BankAccountId = AccId,
                DebitAmount = 0,
                CreditAmount =  amount ?? 0,
                CreationDate = Utility.GetDateTime(),
                ModifyDate = null
            };

            return transaction;
        }

        public static Transaction CreateByBill(Bill entity)
        {
            var transaction = new Transaction
            {
                TransactionId = entity.Id,
                CompanyId = null,
                TransactionTypeId = Constants.TransactionType.BillPayment,
                TransactionDate = Utility.GetDateTime(),
                TransactionNumber = entity.BillNumber,
                ContactType = Constants.ContactType.Vendor,
                ContactId = entity.VendorId,
                BankAccountId = 2,
                DebitAmount = 0,
                CreditAmount = entity.TotalAmount,
                CreationDate = Utility.GetDateTime(),
                ModifyDate = null
            };

            return transaction;
        }

        public static Transaction CreateByBillItemsAndTax(Bill entity, int AccId, decimal? amount)
        {
            var transaction = new Transaction
            {
                TransactionId = entity.Id,
                CompanyId = null,
                TransactionTypeId = Constants.TransactionType.BillPayment,
                TransactionDate = Utility.GetDateTime(),
                TransactionNumber = entity.BillNumber,
                ContactType = Constants.ContactType.Vendor,
                ContactId = entity.VendorId,
                BankAccountId = AccId,
                DebitAmount = amount ?? 0,
                CreditAmount = 0,
                CreationDate = Utility.GetDateTime(),
                ModifyDate = null
            };

            return transaction;
        }

        public static Transaction CreateByCustomerAdvancePayment(InvoicePaymentAddModel model)
        {
            var transaction = new Transaction
            {
                TransactionId = null,
                CompanyId = null,
                TransactionTypeId = Constants.TransactionType.CustomerAdvancePayment,
                TransactionDate = model.PaymentDate,
                TransactionNumber = null,
                ContactType = Constants.ContactType.Customer,
                ContactId = model.CustomerId,
                BankAccountId = model.BankAccountId,
                DebitAmount = model.Amount,
                CreditAmount = 0,
                CreationDate = model.PaymentDate,
                ModifyDate = model.PaymentDate
            };

            return transaction;
        }
        public static Transaction CreateByVendorAdvancePayment(BillPaymentAddModel model)
        {
            var transaction = new Transaction
            {
                TransactionId = null,
                CompanyId = null,
                TransactionTypeId = Constants.TransactionType.VendorAdvancePayment,
                TransactionDate = model.PaymentDate,
                TransactionNumber = null,
                ContactType = Constants.ContactType.Vendor,
                ContactId = model.VendorId,
                BankAccountId = model.BankAccountId,
                DebitAmount = 0,
                CreditAmount = model.Amount,
                CreationDate = model.PaymentDate,
                ModifyDate = model.PaymentDate
            };

            return transaction;
        }

    }
}

