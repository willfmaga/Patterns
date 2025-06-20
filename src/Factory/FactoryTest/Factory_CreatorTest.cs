using Factory.Entities.Animals;
using Factory.Extensions;
using Factory.Interfaces;

namespace FactoryTest
{
    [TestClass]
    public sealed class Factory_CreatorTest
    {
        [TestMethod]
        public void WhenEverythingIsFineResultIsOk()
        {
            //arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Cat;
            //act
            animal = animal.Creator();
            
            //assert 
           Assert.IsInstanceOfType(animal, typeof(Cat));
        }

        [TestMethod]
        public void WhenSpecieIsDogResultIsDog()
        {
            //arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Dog;
            //act
            animal = animal.Creator();

            //assert 
            Assert.IsInstanceOfType(animal, typeof(Dog));
        }

        [TestMethod]
        public void WhenSpecieIsUnknownThrowsException()
        {
            //arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = (Factory.Enumerators.Species)999; // Unknown species

            //act & assert
            Assert.ThrowsException<ArgumentException>(() => animal.Creator());
        }

    }
}
