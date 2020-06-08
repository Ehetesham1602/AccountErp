using AccountErp.Entities;
using AccountErp.Models.BankAccount;
using AccountErp.Utilities;

namespace AccountErp.Factories
{
    public class BankAccountFactory
    {
        public static BankAccount Create(BankAccountAddModel model,string userId)
        {
            BankAccount bankAccount =  new BankAccount
            {
                AccountNumber = model.AccountNumber,
                AccountHolderName = model.AccountHolderName,
                BankName = model.BankName,
                BranchName = model.BranchName,
                Ifsc = model.Ifsc,
                Status = Constants.RecordStatus.Active,
                CreatedBy = userId,
                CreatedOn = Utility.GetDateTime()
            };
            return bankAccount;
        }
        public static void Create(BankAccountEditModel model,BankAccount entity,string userId)
        {
            entity.AccountNumber = model.AccountNumber;
            entity.AccountHolderName = model.AccountHolderName;
            entity.BankName = model.BankName;
            entity.BranchName = model.BranchName;
            entity.Ifsc = model.Ifsc;
            entity.UpdatedBy = userId;
            entity.UpdatedOn = Utility.GetDateTime();
        }
    }
}
