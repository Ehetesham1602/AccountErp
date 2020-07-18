using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.Report
{
    public class SalesTaxDetailsReportDto
    {
        public Decimal? TotalTaxAmountOnSales { get; set; }
        public Decimal TotalTaxAmountOnPurchase { get; set; }
        public List<SalesTaxReportDto> SalesTaxReportDtosList { get; set; }
    }
}
