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
using System.Linq;

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

        public async Task<ReconciliationMainDto> GetAllAsync()
        {
            ReconciliationMainDto mainDetailDto = new ReconciliationMainDto();
            mainDetailDto.mainReconciliationDtos = new List<NewReconciliationDto>();
            var data = await _repository.GetAllAsync();
            var result = (data.GroupBy(l => l.BankAccountId,  l => new { l.BankAccountId, l.StatementBalance, l.ReconciliationDate, l.IcloseBalance, l.bankname, l.IsReconciliation, l.ReconciliationStatus })
            .Select(g => new { GroupId = g.Key, Values = g.ToList() })).ToList();
            foreach(var ban in result)
            {
               NewReconciliationDto newReconcilationDto = new NewReconciliationDto();
                newReconcilationDto.reconciliationDtos = new List<ReconciliationDto>();
                // var id = ban.GroupId;
                //var amount = ban.Values.Sum(x => x.BankAccountId);
                //   amount = ban.Values.Sum(x => x.bankname);
                newReconcilationDto.bankAccountId = ban.GroupId;
                newReconcilationDto.ammount = 0;


                foreach (var item in ban.Values)
                {
                    newReconcilationDto.bankname = item.bankname;

                        ReconciliationDto reconcilationDto = new ReconciliationDto();
                    reconcilationDto.BankAccountId = ban.GroupId;
                    reconcilationDto.ReconciliationDate = item.ReconciliationDate;
                    reconcilationDto.StatementBalance = item.StatementBalance;
                    reconcilationDto.IcloseBalance = item.IcloseBalance;
                    reconcilationDto.bankname = item.bankname;
                    reconcilationDto.IsReconciliation = item.IsReconciliation;
                    reconcilationDto.ReconciliationStatus = item.ReconciliationStatus;
                    newReconcilationDto.reconciliationDtos.Add(reconcilationDto);
                }
                mainDetailDto.mainReconciliationDtos.Add(newReconcilationDto);



            }

           // ReconciliationDto reconcilationDtt = new ReconciliationDto();
            //reconcilationDtt.bankn
         //   mainDetailDto.AccountEndingBalance = 0;
            
            return mainDetailDto;
        }

    }
}
