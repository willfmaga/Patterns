using FactoryBank.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryBank.Entities.Account
{
    public abstract class BaseAccount : IAccount
    {
        public decimal AccountBalance { get; set; }
        public string? AccountType { get; set; }

        public int AccountNumber { get; set; }

        public virtual void Deposit(decimal amount)
        {
            AccountBalance += amount;
        }

        public virtual decimal GetBalance()
        {
            return AccountBalance;
        }

        public virtual string Withdraw(decimal amount)
        {
            if (amount > AccountBalance)
            {
                throw new Exception("Insufficient funds for withdrawal.");
            }

            AccountBalance -= amount;
            return string.Concat("You have withdrawn ", amount, " from your account. Your new balance is ", AccountBalance);
        }
    }
}
