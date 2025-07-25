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

        public override string Withdraw(decimal amount)
        {
            var retorno = base.Withdraw(amount);

            //logica de enviar email 
            return retorno;
        }
    }
}
