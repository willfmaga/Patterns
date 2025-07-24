using FactoryBank.Entities.Account;
using FactoryBank.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryBank.Factory
{
    public class AccountFactory
    {

        public static IAccount Create(string accountType)
        {
            switch (accountType)
            {
                case "Savings":
                    return new SavingsAccount();
                case "Checking":
                    return new CheckingAccount();
                default:
                    throw new ArgumentException("Unknown account type");
            }
        }
    }
}
