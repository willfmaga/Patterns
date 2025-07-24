using FactoryBank.Entities.Account;
using FactoryBank.Factory;
using FactoryBank.Interface;

namespace AccountFactoryTest
{
    [TestClass]
    public sealed class BankAccount_FactoryTest
    {
        [TestMethod]
        public void WhenEverythingIsFineResultIsOk()
        {
            //arrange 
            //act
            IAccount account = AccountFactory.Create("Savings");

            //assert 
            Assert.IsInstanceOfType(account, typeof(SavingsAccount));
        }

        [TestMethod]
        public void WhenAccountIsCheckingResultOk()
        {
            //arrange 
            //act
            IAccount account = AccountFactory.Create("Checking");


            //assert 
            Assert.IsInstanceOfType(account, typeof(CheckingAccount));
        }

        [TestMethod]
        public void WhenAccountUnknownThrowsException()
        {
            //arrange 
            //act & assert
            Assert.ThrowsException<ArgumentException>(() => AccountFactory.Create("Investment"));

        }

    }
}
