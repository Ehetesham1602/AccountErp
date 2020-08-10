using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class ProfitAndLossMainDto
    {
        public Decimal GrossProfit { get; set; }
        public Decimal NetProfit { get; set; }
        public List<ProfitAndLossDetailsDto> mainProfitAndLossDetailsList { get; set; }
    }
}
