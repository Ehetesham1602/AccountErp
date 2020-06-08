using AccountErp.Dtos;
using AccountErp.Dtos.Bill;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Bill;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class BillManager : IBillManager
    {
        private readonly IBillRepository _repository;
        private readonly IItemRepository _itemRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public BillManager(IHttpContextAccessor contextAccessor,
            IBillRepository repository, IItemRepository itemRepository,
            IVendorRepository vendorRepository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _repository = repository;
            _itemRepository = itemRepository;
            _vendorRepository = vendorRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(BillAddModel model)
        {
            var items = (await _itemRepository.GetAsync(model.Items)).ToList();

            model.TotalAmount = items.Sum(x => x.Rate);

            model.Tax = items.Where(x => x.IsTaxable).Sum(x => x.Rate * x.SalesTax.TaxPercentage / 100);

            var vendor = await _vendorRepository.GetAsync(model.VendorId);

            if (vendor.Discount != null)
            {
                model.Discount = model.TotalAmount * vendor.Discount / 100;
                model.TotalAmount = model.TotalAmount - (model.Discount ?? 0);
            }

            if (model.Tax != null)
            {
                model.TotalAmount = model.TotalAmount + (model.Tax ?? 0);
            }

            await _repository.AddAsync(BillFactory.Create(model, _userId, items));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Editsync(BillEditModel model)
        {
            var items = (await _itemRepository.GetAsync(model.Items)).ToList();

            model.TotalAmount = items.Sum(x => x.Rate);

            model.Tax = items.Where(x => x.IsTaxable).Sum(x => x.Rate * x.SalesTax.TaxPercentage / 100);

            var vendor = await _vendorRepository.GetAsync(model.VendorId);

            if (vendor.Discount != null)
            {
                model.Discount = model.TotalAmount * vendor.Discount / 100;
                model.TotalAmount = model.TotalAmount - (model.Discount ?? 0);
            }

            if (model.Tax != null)
            {
                model.TotalAmount = model.TotalAmount + (model.Tax ?? 0);
            }

            var bill = await _repository.GetAsync(model.Id);

            BillFactory.Edit(bill, model, _userId, items);

            _repository.Edit(bill);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<JqDataTableResponse<BillListItemDto>> GetPagedResultAsync(BillJqDataTableRequestModel model)
        {
            return await _repository.GetPagedResultAsync(model);
        }

        public async Task<List<BillListItemDto>> GetRecentAsync()
        {
            return await _repository.GetRecentAsync();
        }

        public async Task<BillDetailDto> GetDetailAsync(int id)
        {
            return await _repository.GetDetailAsync(id);
        }

        public async Task<BillDetailForEditDto> GetDetailForEditAsync(int id)
        {
            return await _repository.GetDetailForEditAsync(id);
        }

        public async Task<BillSummaryDto> GetSummaryAsunc(int id)
        {

            return await _repository.GetSummaryAsunc(id);
        }

        public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync()
        {
            return await _repository.GetSelectItemsAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
