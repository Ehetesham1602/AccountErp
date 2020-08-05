using AccountErp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction entity);
        Task SetTransactionAccountIdForInvoice(int invoiceId, int? AccId, DateTime date);
        Task SetTransactionAccountIdForBill(int billId, int? AccId, DateTime date);
    }
}
