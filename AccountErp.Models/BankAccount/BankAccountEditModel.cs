using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountErp.Models.BankAccount
{
    public class BankAccountEditModel
    {
        public int Id { get; set; }
        [Required]
        public string AccountNumber { get; set; }

        [Required]
        public string AccountHolderName { get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        public string BranchName { get; set; }
        [Required]
        public string Ifsc { get; set; }
        [Required]
        public int COA_AccountTypeId { get; set; }
        public string AccountCode { get; set; }
        public string Description { get; set; }
    }
}
