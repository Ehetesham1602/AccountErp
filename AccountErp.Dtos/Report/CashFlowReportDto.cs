using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class CashFlowReportDto
    {
        public int Id { get; set; }
        public String AccountMasterName { get; set; }
        public List<CashFlowDetailsReportDto> BankAccount { get; set; }
    }
}
