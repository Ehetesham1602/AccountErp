using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using AccountErp.Dtos;
using AccountErp.Dtos.Item;
using AccountErp.Factories;
using AccountErp.Infrastructure.DataLayer;
using AccountErp.Infrastructure.Managers;
using AccountErp.Infrastructure.Repositories;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using AccountErp.Models.Reconciliation;
using AccountErp.Dtos.Reconciliation;
using AccountErp.Entities;

namespace AccountErp.Managers
{
  public  class ReconciliationManager : IReconciliationManager
    {
        private readonly IReconciliationRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly string _userId;

        public ReconciliationManager(IHttpContextAccessor contextAccessor,
            IReconciliationRepository repository,
            IUnitOfWork unitOfWork)
        {
            _userId = contextAccessor.HttpContext.User.GetUserId();

            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(ReconciliationAddModel model)
        {
            await _repository.AddAsync(ReconciliationFactory.Create(model, _userId));
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task EditAsync(ReconciliationEditModel model)
        {
            var item = await _repository.GetAsync(model.Id);
            ReconciliationFactory.Create(model, item, _userId);
            _repository.Edit(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Reconciliation> GetDetailAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<ReconciliationDto>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

    }
}
