using FactoryBank.Entities.Account;
using FactoryBank.Factory;
using FactoryBank.Interface;

namespace AccountFactoryTest
{
    [TestClass]
    public sealed class BankAccount_Withdraw_Deposit_Test
    {
        [TestMethod]
        public void WhenAccountCheckingDepositIsOk()
        {
            // arrange 
            IAccount account = AccountFactory.Create("Checking");
            
            // act 
            account.Deposit(10.5m);

            // assert 
            Assert.AreEqual(10.5m, account.GetBalance());
            
        }

        [TestMethod]
        public void WhenAccountSavingsWithMoneyGetBalanceIsOk()
        {
            // arrange 
            IAccount account = AccountFactory.Create("Savings");
            account.Deposit(9.8m);

            // act 
            var balance = account.GetBalance();

            // assert 
            Assert.AreEqual(9.8m, account.GetBalance());
        }

      
        [TestMethod]
        public void WhenCheckingAccountWithoutMoneyWhenWithdrawalThrowsException()
        {
            // arrange 
            IAccount account =AccountFactory.Create("Checking");

            // act 
            // assert 
            Assert.ThrowsException<Exception>(() => account.Withdraw(2m));

        }

        [TestMethod]
        public void WhenAccountSavingsWithMoneyWithdrawalOk()
        {
            // arrange 
            IAccount account = AccountFactory.Create("Savings");
            account.Deposit(9.8m);

            // act 
            var balance = account.Withdraw(5m);

            // assert 
            Assert.AreEqual(4.8m, account.GetBalance());
        }
    }
}
