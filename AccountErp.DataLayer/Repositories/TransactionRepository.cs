using AccountErp.Entities;
using AccountErp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace AccountErp.DataLayer.Repositories
{
    public class TransactionRepository: ITransactionRepository
    {
        private readonly DataContext _dataContext;

        public TransactionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task AddAsync(Transaction entity)
        {
            await _dataContext.Transaction.AddAsync(entity);
        }

        public async Task SetTransactionAccountIdForInvoice(int invoiceId, int? AccId, DateTime date)
        {
            var linqstmt = await (from t in _dataContext.Transaction
                                  where t.TransactionId == invoiceId
                                  select t
                            ).AsNoTracking()
                            .ToListAsync();

            foreach (var item in linqstmt)
            {
               if(item.BankAccountId == 1)
                {
                    item.BankAccountId = AccId;
                }
                item.ModifyDate = date;
                item.Status = Utilities.Constants.TransactionStatus.Paid;
                _dataContext.Transaction.Update(item);
            }
           
        }
        public async Task SetTransactionAccountIdForBill(int billId, int? AccId, DateTime date)
        {
            var linqstmt = await (from t in _dataContext.Transaction
                                  where t.TransactionId == billId
                                  select t
                            ).AsNoTracking()
                            .ToListAsync();

            foreach (var item in linqstmt)
            {
                if (item.BankAccountId == 2)
                {
                    item.BankAccountId = AccId;
                }
                item.ModifyDate = date;
                item.Status = Utilities.Constants.TransactionStatus.Paid;
                _dataContext.Transaction.Update(item);
            }

        }
    }
}
