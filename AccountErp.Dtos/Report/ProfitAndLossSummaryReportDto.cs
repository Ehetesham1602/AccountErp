using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class ProfitAndLossSummaryReportDto
    {
        public Decimal Income { get; set; }
        public Decimal CostOfGoodSold { get; set; }
        public Decimal GrossProfit { get; set; }
        public Decimal OperatingExpenses { get; set; }
        public Decimal NetProfit { get; set; }
    }
}
