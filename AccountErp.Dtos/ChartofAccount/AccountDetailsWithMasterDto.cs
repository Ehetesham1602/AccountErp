using AccountErp.Dtos.BankAccount;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountErp.Dtos.ChartofAccount
{
    public class AccountDetailsWithMasterDto
    {
        public int Id { get; set; }
        public String AccountMasterName { get; set; }
        public List<BankAccountDetailDto> BankAccount { get; set; }
    }
}
