using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Transaction
{
    public class TransactionDetailDto
    {
        public int Id { get; set; }
        public int? TransactionId { get; set; }
        public int? BankAccountId { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public Constants.TransactionStatus Status { get; set; }
 
    }
}
