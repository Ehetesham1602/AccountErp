using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class AgedPayablesReportDto
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public Decimal TotalAmount { get; set; }
        public Decimal TotalUnpaid { get; set; }
    }
}
