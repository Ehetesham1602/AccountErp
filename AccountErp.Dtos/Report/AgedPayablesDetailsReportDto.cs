using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class AgedPayablesDetailsReportDto
    {
        public Decimal TotalAmount { get; set; }
        public Decimal TotalUnpaidAmount { get; set; }
        public List<AgedPayablesReportDto> AgedPayablesReportDtoList { get; set; }
    }
}
