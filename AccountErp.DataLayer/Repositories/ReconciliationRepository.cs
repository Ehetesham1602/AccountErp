﻿using AccountErp.Dtos.Reconciliation;
using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AccountErp.DataLayer.Repositories
{
  public  class ReconciliationRepository : IReconciliationRepository
    {

        private readonly DataContext _dataContext;

        public ReconciliationRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Reconciliation entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public void Edit(Reconciliation entity)
        {
            _dataContext.Update(entity);
        }

        public async Task<Reconciliation> GetAsync(int id)
        {
            return await _dataContext.Reconciliation.FindAsync(id);
        }

        public async Task<IEnumerable<ReconciliationDto>> GetAllAsync()
        {
            return await (from s in _dataContext.Reconciliation
                          select new ReconciliationDto 
                          {
                              Id = s.Id,
                              BankAccountId = s.BankAccountId,
                              ReconciliationDate = s.ReconciliationDate,
                              StartingBalance = s.StartingBalance,
                              EndingBalance = s.EndingBalance,
                              IsReconciliation = s.IsReconciliation,
                              ReconciliationStatus = s.ReconciliationStatus,
                              bankname=s.bank.AccountName
                          })
                          .AsNoTracking()
                            .ToListAsync();
        }

    }
}
