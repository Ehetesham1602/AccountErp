using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class ProfitAndLossDetailsDto
    {
        public int Id { get; set; }
        public String AccountMasterName { get; set; }
        public List<ProfitAndLossDetailsReportDto> BankAccount { get; set; }
    }
}
