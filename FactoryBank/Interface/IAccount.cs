using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryBank.Interface
{
    public interface IAccount
    {
        void Deposit(decimal amount);

        string Withdraw(decimal amount);

        decimal GetBalance();
    }
}
