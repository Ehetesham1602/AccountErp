﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Entities
{
    public class COA_AccountType
    {
        public int Id { get; set; }
        public int COA_AccountMasterId { get; set; }
        public String AccountTypeName { get; set; }
        public ICollection<COA_Account> Account { get; set; }
    }
}
