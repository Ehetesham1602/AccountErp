﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Transaction
{
  public  class TransactionBankDto
    {
        public string BankName { get; set; }
        public TransactionDetailDto TransactionRecords { get; set; }
    }
}
