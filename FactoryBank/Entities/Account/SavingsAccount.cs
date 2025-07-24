using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryBank.Entities.Account
{
    public class SavingsAccount : BaseAccount
    {
        public decimal InterestRate { get; set; } = 0.02m; // Default interest rate of 2%
        public decimal SavingsBalance { get; set; }

        public SavingsAccount()
        {
            this.AccountType = "Savings Account";
            this.AccountNumber = 2;

        }

        public override string Withdraw(decimal amount)
        {
            if (amount > SavingsBalance)
            {
                throw new Exception("Insufficient funds for withdrawal.");
            }
            else
            {
                SavingsBalance -= amount;
                AccountBalance += amount;
            }

            return base.Withdraw(amount);
        }

        public override void Deposit(decimal amount)
        {
            base.Deposit(amount);

            AccountBalance -= amount;
            SavingsBalance += amount;

        }

        public void ApplyInterest()
        {
            decimal interest = SavingsBalance * InterestRate;
            SavingsBalance += interest;

        }

        public override decimal GetBalance()
        {
            return SavingsBalance;
        }
    }
}
