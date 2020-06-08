using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AccountErp.Dtos.Invoice;

namespace AccountErp.Managers
{
    public class InvoicePaymentManager : IInvoicePaymentManager
    {
        private readonly IInvoicePaymentRepository _invoicePaymentRepository;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public InvoicePaymentManager(IHttpContextAccessor contextAccessor,
            IInvoicePaymentRepository invoicePaymentRepository, ICustomerRepository customerRepository,
            IInvoiceRepository invoiceRepository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _invoicePaymentRepository = invoicePaymentRepository;
            _invoiceRepository = invoiceRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(InvoicePaymentAddModel model)
        {
            var invoiceSummary = await _invoiceRepository.GetSummaryAsunc(model.InvoiceId);

            var customerPaymentInfo = await _customerRepository.GetPaymentInfoAsync(invoiceSummary.CustomerId);

            var invoicePayment = InvoicePaymentFactory.Create(model, customerPaymentInfo.AccountNumber, invoiceSummary.TotalAmount, _userId);

            await _invoicePaymentRepository.AddAsync(invoicePayment);

            await _invoiceRepository.UpdateStatusAsync(model.InvoiceId, Constants.InvoiceStatus.Paid);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<JqDataTableResponse<InvoicePaymentListItemDto>> GetPagedResultAsync(InvoiceJqDataTableRequestModel model)
        {
            return await _invoicePaymentRepository.GetPagedResultAsync(model);
        }
    }
}
