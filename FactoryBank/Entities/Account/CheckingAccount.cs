using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryBank.Entities.Account
{
    public class CheckingAccount : BaseAccount
    {
        public CheckingAccount()
        {
            this.AccountType = "Checking Account";
            this.AccountNumber = 1;
        }
    }
}
