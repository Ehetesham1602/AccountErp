using System;
using System.Collections.Generic;
using System.Text;
using AccountErp.Dtos.ChartofAccount;
namespace AccountErp.Dtos.Report
{
    public class ProfitAndLossDetailsReportDto
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal IncomeDebitAmount { get; set; }
        public decimal OperatingExpensesCreditAmount { get; set; }
        
    }
}
