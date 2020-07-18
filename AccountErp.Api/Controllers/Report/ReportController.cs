using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using AccountErp.Infrastructure.Managers;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Report;
using AccountErp.Dtos.Customer;
using AccountErp.Models.Report;

namespace AccountErp.Api.Controllers.Report
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[Authorize]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportManager _reportManager;
        public ReportController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }

        [HttpPost]
        [Route("vendor_report_details")]
        public async Task<VendorDetailsReportDto> GetVendorReportAsync(VendorReportModel model)
        {
            var pagedResult = await _reportManager.GetVendorReportAsync(model);
            return pagedResult;
        }

        [HttpPost]
        [Route("customer_report_details")]
        public async Task<CustomerDetailsReportDto> GetCustomerReportAsync(CustomerReportModel model)
        {
            var pageResult = await _reportManager.GetCustomerReportAsync(model);
            return pageResult;
        }

        [HttpPost]
        [Route("sales_tax_report_details")]
        public async Task<SalesTaxDetailsReportDto> GetSalesTaxReportAsync(SalesReportModel model)
        {
            var pageResult = await _reportManager.GetSalesTaxReportAsync(model);
            return pageResult;
        }
    }
}
