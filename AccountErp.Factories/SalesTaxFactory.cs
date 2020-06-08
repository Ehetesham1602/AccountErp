using AccountErp.Entities;
using AccountErp.Models.SalesTax;
using AccountErp.Models.VendorSalesTax;

namespace AccountErp.Factories
{
    public class SalesTaxFactory
    {
        public static SalesTax Create(SalesTaxAddModel addModel,string userId)
        {
            var salesTax = new SalesTax
            {
                Code = addModel.Code,
                Description = addModel.Description,
                TaxPercentage = addModel.TaxPercentage,
                CreatedBy = userId,
                CreatedOn = Utilities.Utility.GetDateTime(),
                Status = Utilities.Constants.RecordStatus.Active
            };
            return salesTax;
        }

        public static void Create(SalesTaxEditModel salesTaxEditModel,SalesTax salesTax,string userId)
        {
            salesTax.Code = salesTaxEditModel.Code;
            salesTax.Description = salesTaxEditModel.Description;
            salesTax.TaxPercentage = salesTaxEditModel.TaxPercentage;
            salesTax.UpdatedBy = userId;
            salesTax.UpdatedOn = Utilities.Utility.GetDateTime();
        }
    }
}
