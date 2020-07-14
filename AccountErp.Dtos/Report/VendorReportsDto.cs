using AccountErp.Dtos.Bill;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class VendorReportsDto
    { 
        public int Id;
        public string VendorName;
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public Decimal TotalPaidAmount { get; set; }
        public Decimal TotalAmount { get; set; }
        public string status { get; set; }
    }
}


