using Factory.Entities.Animals;
using Factory.Entities.Factory;
using Factory.Interfaces;

namespace FactoryTest
{
    [TestClass]
    public sealed class Factory_FactoryTest
    {
        [TestMethod]
        public void WhenEverythingIsFineResultIsOk()
        {
            //arrange 
            //act
            IAnimal animal = AnimalFactory.Create(Factory.Enumerators.Species.Cat);
            
            
            //assert 
           Assert.IsInstanceOfType(animal, typeof(Cat));
        }

        [TestMethod]
        public void WhenSpecieIsDogResultIsDog()
        {
            //arrange 
            //act
            IAnimal animal = AnimalFactory.Create(Factory.Enumerators.Species.Dog);
            

            //assert 
            Assert.IsInstanceOfType(animal, typeof(Dog));
        }

        [TestMethod]
        public void WhenSpecieIsUnknownThrowsException()
        {
            //arrange 
            //act & assert
            Assert.ThrowsException<ArgumentException>(() =>  AnimalFactory.Create((Factory.Enumerators.Species)999));
           

        }

    }
}
