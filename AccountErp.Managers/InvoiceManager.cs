using AccountErp.Dtos.Invoice;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Invoice;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class InvoiceManager : IInvoiceManager
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IItemRepository _itemRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public InvoiceManager(IHttpContextAccessor contextAccessor,
            IInvoiceRepository invoiceRepository,
            IUnitOfWork unitOfWork,
            IItemRepository itemRepository,
            ICustomerRepository customerRepository)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _invoiceRepository = invoiceRepository;
            _itemRepository = itemRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(InvoiceAddModel model)
        {
           // var items = (await _itemRepository.GetAsync(model.Items)).ToList();

            //model.TotalAmount = items.Sum(x => x.Rate);

            //model.Tax = items.Where(x => x.IsTaxable).Sum(x => x.Rate * x.SalesTax.TaxPercentage / 100);

            //var customer = await _customerRepository.GetAsync(model.CustomerId);

            //if (customer.Discount != null)
            //{
            //    model.Discount = model.TotalAmount * customer.Discount / 100;
            //    model.TotalAmount = model.TotalAmount - (model.Discount ?? 0);
            //}

            //if (model.Tax != null)
            //{
            //    model.TotalAmount = model.TotalAmount + (model.Tax ?? 0);
            //}

            var count = await _invoiceRepository.getCount();

            //await _invoiceRepository.AddAsync(InvoiceFactory.Create(model, _userId, items));
            await _invoiceRepository.AddAsync(InvoiceFactory.Create(model, _userId, count));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(InvoiceEditModel model)
        {
            //var items = (await _itemRepository.GetAsync(model.Items)).ToList();

            //model.TotalAmount = items.Sum(x => x.Rate);

            //model.Tax = items.Where(x => x.IsTaxable).Sum(x => x.Rate * x.SalesTax.TaxPercentage / 100);

            //var customer = await _customerRepository.GetAsync(model.CustomerId);

            //if (customer.Discount != null)
            //{
            //    model.Discount = model.TotalAmount * customer.Discount / 100;
            //    model.TotalAmount = model.TotalAmount - (model.Discount ?? 0);
            //}

            //if (model.Tax != null)
            //{
            //    model.TotalAmount = model.TotalAmount + (model.Tax ?? 0);
            //}

            var invoice = await _invoiceRepository.GetAsync(model.Id);

            //InvoiceFactory.Create(model, invoice, _userId, items);
            InvoiceFactory.EditInvoice(model, invoice, _userId);

            _invoiceRepository.Edit(invoice);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<InvoiceDetailDto> GetDetailAsync(int id)
        {
            return await _invoiceRepository.GetDetailAsync(id);
        }

        public async Task<InvoiceDetailForEditDto> GetForEditAsync(int id)
        {
            return await _invoiceRepository.GetForEditAsync(id);
        }

        public async Task<JqDataTableResponse<InvoiceListItemDto>> GetPagedResultAsync(InvoiceJqDataTableRequestModel model)
        {
            return await _invoiceRepository.GetPagedResultAsync(model);
        }

        public async Task<List<InvoiceListItemDto>> GetRecentAsync()
        {
            return await _invoiceRepository.GetRecentAsync();
        }

        public async Task<InvoiceSummaryDto> GetSummaryAsunc(int id)
        {
            return await _invoiceRepository.GetSummaryAsunc(id);
        }

        public async Task DeleteAsync(int id)
        {
            await _invoiceRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> GetInvoiceNumber()
        {
            var count = await _invoiceRepository.getCount();
            return (count + 1);
        }
    }
}
