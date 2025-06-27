using Factory.Entities.Animals;
using Factory.Entities.Factory;
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
            IAnimal animal = AnimalFactory.Create(Factory.Enumerators.Species.Dog);
            
            // act 
            var sound = animal.MakeSound();

            // assert 
            Assert.AreEqual("Au au au", sound);
        }

        [TestMethod]
        public void WhenAnimalIsCatSoundLikeMiauMiau()
        {
            // arrange 
            IAnimal animal = AnimalFactory.Create(Factory.Enumerators.Species.Cat);

            // act 
            var sound = animal.MakeSound();
            // assert 
            Assert.AreEqual("Miau miau", sound);
        }

        [TestMethod]
        public void WhenAnimalIsBirdSoundLikePiuPiu()
        {
            // arrange 
            IAnimal animal = AnimalFactory.Create(Factory.Enumerators.Species.Bird);

            // act 
            var sound = animal.MakeSound();

            // assert 
            Assert.AreEqual("Piu piu", sound);
        }

        [TestMethod]
        public void WhenAnimalIsWolfSoundLikeAuauAuuuuuuu()
        {
            // arrange 
            IAnimal animal =AnimalFactory.Create(Factory.Enumerators.Species.Wolf);

            // act 
            var sound = animal.MakeSound();

            // assert 
            Assert.AreEqual("Au au au Auuuuuuu", sound);
        }
    }
}
