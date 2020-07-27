using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int DebitAccId { get; set; }
        public int CreditAccId { get; set; }
        public int TransactionTypeId { get; set; }
        public int PaymentTypeId { get; set; }
        public string Description { get; set; }
        public DateTime TranscDate { get; set; }
        public Decimal Amount { get; set; }
        public int Status { get; set; }




    }
}
