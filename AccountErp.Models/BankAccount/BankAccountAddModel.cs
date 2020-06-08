using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AccountErp.Models.BankAccount
{
    public class BankAccountAddModel
    {
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
    }
}
