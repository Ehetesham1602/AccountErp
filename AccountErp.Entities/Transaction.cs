using System;
using System.Collections.Generic;
using System.Text;
using static AccountErp.Utilities.Constants;

namespace AccountErp.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int CompanyId { get; set; }
        public int AccountId { get; set; }
        public int ContactId { get; set; }
        public int TransactionTypeId { get; set; }
        public string TransactionNumber { get; set; }
        public string Description { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public DateTime CreaionDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public ContactType ContactType { get; set; }
        public int Status { get; set; }




    }
}
