using AccountErp.Dtos;
using AccountErp.Dtos.Bill;
using AccountErp.Dtos.Customer;
using AccountErp.Dtos.Report;
using AccountErp.Entities;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Customer;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class ReportManager : IReportManager
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public ReportManager(IHttpContextAccessor contextAccessor,
            IReportRepository reportRepository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<VendorDetailsReportDto> GetVendorReportAsync(VendorReportsDto model)
        {
            VendorDetailsReportDto vendorDetailsReportDtoObj = new VendorDetailsReportDto();
            List<VendorReportsDto> tempModel = await _reportRepository.GetVendorReportAsync(model);

            vendorDetailsReportDtoObj.vendorReportsList = tempModel;
            vendorDetailsReportDtoObj.TotalPurchaseAmount = tempModel.Sum(x => x.TotalAmount);
            vendorDetailsReportDtoObj.TotalPaidAmount = tempModel.Sum(x => x.TotalPaidAmount);
            /* foreach (BillSummaryDto billSummary in tempModel)
            {
                billSummary.paidAmount = (billSummary.status == "1") ? billSummary.TotalAmount : 0;

            }
           */
            return vendorDetailsReportDtoObj;
        }

    }
}
