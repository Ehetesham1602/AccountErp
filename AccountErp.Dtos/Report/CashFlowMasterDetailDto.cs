﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class CashFlowMasterDetailDto
    {
        public List<CashFlowDetailsReportDto> OperatingActivities { get; set; }
        public List<CashFlowDetailsReportDto> Overview { get; set; }
    }
}
