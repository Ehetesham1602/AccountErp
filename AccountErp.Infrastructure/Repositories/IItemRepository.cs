﻿using AccountErp.Dtos;
using AccountErp.Dtos.Item;
using AccountErp.Entities;
using AccountErp.Models.Item;
using AccountErp.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountErp.Infrastructure.Repositories
{
    public interface IItemRepository
    {
        Task AddAsync(Item entity);

        void Edit(Item entity);

        Task<Item> GetAsync(int id);

        Task<IEnumerable<Item>> GetAsync(List<int> itemIds);

        Task<ItemDetailDto> GetDetailAsync(int id);

        Task<IEnumerable<ItemDetailDto>> GetAllAsync(Constants.RecordStatus? status = null);

        Task<IEnumerable<ItemDetailDto>> GetAllForSalesAsync(Constants.RecordStatus? status = null);
        Task<IEnumerable<ItemDetailDto>> GetAllForExpenseAsync(Constants.RecordStatus? status = null);



        

        Task<ItemDetailForEditDto> GetForEditAsync(int id);

        Task<JqDataTableResponse<ItemListItemDto>> GetPagedResultAsync(ItemJqDataTableRequestModel model);

        Task<IEnumerable<SelectListItemDto>> GetSelectItemsAsync();

        Task ToggleStatusAsync(int id);

        Task DeleteAsync(int id);
    }
}
