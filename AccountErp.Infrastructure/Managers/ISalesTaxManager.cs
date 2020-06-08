using AccountErp.Dtos;
using AccountErp.Dtos.SalesTax;
using AccountErp.Models.SalesTax;
using AccountErp.Models.VendorSalesTax;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Managers
{
    public interface ISalesTaxManager
    {
        Task AddAsync(SalesTaxAddModel model);

        Task EditAsync(SalesTaxEditModel model);

        Task<SalesTaxDetailDto> GetForEditAsync(int id);

        Task<bool> IsCodeExistsAsync(string code);
        Task<bool> IsCodeExistsAsync(string code,int id);

        Task<IEnumerable<SelectListItemDto>> GetSelectListItemsAsync();

        Task<JqDataTableResponse<SalesTaxListItemDto>> GetPagedResultAsync(JqDataTableRequest model);

        Task ToggleStatusAsync(int id);

        Task DeleteAsync(int id);
    }
}
