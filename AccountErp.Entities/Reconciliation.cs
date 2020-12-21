﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Entities
{
   public class Reconciliation
    {

        public int Id { get; set; }
        public int BankAccountId  { get; set; }
        public DateTime ReconciliationDate { get; set; }
        public Decimal StartingBalance { get; set; }
        public Decimal EndingBalance { get; set; }

        public bool IsReconciliation { get; set; }

        public int ReconciliationStatus { get; set; }
        public BankAccount bank { get; set; }



    }
}
