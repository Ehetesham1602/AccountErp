﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class CashFlowDetailsReportDto
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal Amount { get; set; }
    }
}
