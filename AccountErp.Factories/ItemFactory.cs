using AccountErp.Entities;
using AccountErp.Models.Item;
using AccountErp.Utilities;

namespace AccountErp.Factories
{
    public class ItemFactory
    {
        public static Item Create(ItemAddModel model, string userId)
        {
            var item = new Item
            {
                ItemTypeId = model.ItemTypeId,
                Name = model.Name,
                Rate = model.Rate,
                Description = model.Description,
                IsTaxable = model.IsTaxable?.Equals("1") ?? false,
                SalesTaxId = model.SalesTaxId,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId,
                CreatedOn = Utility.GetDateTime()
            };
            return item;
        }
        public static void Create(ItemEditModel model, Item entity, string userId)
        {
            entity.ItemTypeId = model.ItemTypeId;
            entity.Name = model.Name;
            entity.Rate = model.Rate;
            entity.Description = model.Description;
            entity.IsTaxable = model.IsTaxable?.Equals("1") ?? false;
            entity.SalesTaxId = entity.IsTaxable ? model.SalesTaxId : null;
            entity.UpdatedBy = userId;
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
