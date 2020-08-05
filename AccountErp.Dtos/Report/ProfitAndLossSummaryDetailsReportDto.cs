using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Invoice;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class ProfitAndLossSummaryDetailsReportDto
    {
        public List<BillDetailDto> billDetailDto { get; set; }
        public List<InvoiceDetailDto> InvoiceDetailDto { get; set; }
    }
}
