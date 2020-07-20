using AccountErp.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.BankAccount
{
    public class BankAccountDetailDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string Ifsc { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
        public int? COA_AccountTypeId { get; set; }
        public Constants.RecordStatus Status { get; set; }
    }
}
