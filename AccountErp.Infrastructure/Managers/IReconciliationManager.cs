using AccountErp.Dtos.Reconciliation;
using AccountErp.Entities;
using AccountErp.Models.Reconciliation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
   public interface IReconciliationManager
    {
        Task AddAsync(ReconciliationAddModel model);

        Task EditAsync(ReconciliationEditModel model);

        Task<Reconciliation> GetDetailAsync(int id);

        Task<IEnumerable<ReconciliationDto>> GetAllAsync();

    }
}
