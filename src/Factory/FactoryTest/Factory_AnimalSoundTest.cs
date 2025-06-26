using Factory.Entities.Animals;
using Factory.Extensions;
using Factory.Interfaces;

namespace FactoryTest
{
    [TestClass]
    public sealed class Factory_AnimalSoundTest
    {
        [TestMethod]
        public void WhenAnimalIsDogSoundLikeAuau()
        {
            // arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Dog;

            // act 
            animal = animal.Factory();

            // assert 
            Assert.AreEqual("Au au au", animal.MakeSound());
        }

        [TestMethod]
        public void WhenAnimalIsCatSoundLikeMiauMiau()
        {
            // arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Cat;

            // act 
            animal = animal.Factory();

            // assert 
            Assert.AreEqual("Miau miau", animal.MakeSound());
        }

        [TestMethod]
        public void WhenAnimalIsBirdSoundLikePiuPiu()
        {
            // arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Bird;

            // act 
            animal = animal.Factory();

            // assert 
            Assert.AreEqual("Piu piu", animal.MakeSound());
        }

        [TestMethod]
        public void WhenAnimalIsWolfSoundLikeAuauAuuuuuuu()
        {
            // arrange 
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Wolf;

            // act 
            animal = animal.Factory();

            // assert 
            Assert.AreEqual("Au au au Auuuuuuu", animal.MakeSound());
        }
    }
}
