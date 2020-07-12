using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountErp.Dtos;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Report;

namespace AccountErp.Infrastructure.Managers
{
    public interface IReportManager
    {
        Task<VendorDetailsReportDto> GetVendorReportAsync(VendorReportsDto model);
    }
}
