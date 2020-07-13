using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Report;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IReportRepository
    {
       Task<List<VendorReportsDto>> GetVendorReportAsync(VendorReportsDto model);
    }
}
