﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Models.Report
{
    public class ProfitAndLossModel
    {
        public DateTime DateRange { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReportType { get; set; }
    }
}