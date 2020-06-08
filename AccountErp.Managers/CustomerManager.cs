using AccountErp.Dtos;
using AccountErp.Dtos.Customer;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Customer;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly string _userId;

        public CustomerManager(IHttpContextAccessor contextAccessor,
            ICustomerRepository customerRepository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(CustomerAddModel model)
        {
            var customer = CustomerFactory.Create(model, _userId);
            await _customerRepository.AddAsync(customer);
            await _unitOfWork.SaveChangesAsync();
            return customer.Id;
        }

        public async Task EditAsync(CustomerEditModel model)
        {
            var customer = await _customerRepository.GetAsync(model.Id);
            CustomerFactory.Update(model, customer, _userId);
            _customerRepository.Edit(customer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<CustomerDetailDto> GetDetailAsync(int id)
        {
            return await _customerRepository.GetDetailAsync(id);
        }
        public async Task<CustomerDetailDto> GetForEditAsync(int id)
        {
            return await _customerRepository.GetForEditAsync(id);
        }

        public async Task<JqDataTableResponse<CustomerListItemDto>> GetPagedResultAsync(JqDataTableRequest model)
        {
            return await _customerRepository.GetPagedResultAsync(model);
        }

        public async Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync()
        {
            return await _customerRepository.GetSelectItemsAsync();
        }

        public async Task ToggleStatusAsync(int id)
        {
            await _customerRepository.ToggleStatusAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _customerRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            return await _customerRepository.IsEmailExistsAsync(email);
        }

        public async Task<bool> IsEmailExistsAsync(int id, string email)
        {
            return await _customerRepository.IsEmailExistsAsync(id, email);
        }
        
        public async Task<CustomerPaymentInfoDto> GetPaymentInfoAsync(int id)
        {
            return await _customerRepository.GetPaymentInfoAsync(id);
        }
    }
}
