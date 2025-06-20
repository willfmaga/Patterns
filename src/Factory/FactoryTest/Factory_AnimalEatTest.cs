using Factory.Entities.Animals;
using Factory.Entities.Foods;
using Factory.Extensions;
using Factory.Interfaces;

namespace FactoryTest
{
    [TestClass]
    public sealed class Factory_AnimalEatTest
    {
        [TestMethod]
        public void WhenAnimalIsDogAndFoodAsWellToEatReturnsTrue()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Dog;
            animal = animal.Creator();
            var food = new DogFood();

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAnimalIsDogAndFoodIsDefaultToEatReturnsTrue()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Dog;
            animal = animal.Creator();
            var food = new Food();

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAnimalIsDogAndFoodIsBirdFoodToEatReturnsFalse()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Dog;
            animal = animal.Creator();
            var food = new BirdFood();

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WhenAnimalIsCatToEatReturnsTrue()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Cat;
            animal = animal.Creator();
            var food = new CatFood() ;

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAnimalIsBirdAndFoodIsNotToBirdToEatReturnsFalse()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Bird;
            animal = animal.Creator();
            var food = new Food();

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsFalse(result, "The food isn't for Bird");
        }

        [TestMethod]
        public void WhenAnimalIsBirdAndFoodAsWellToEatReturnsTrue()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Bird;
            animal = animal.Creator();
            var food = new BirdFood();

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void WhenAnimalIsWolfToEatReturnsTrue()
        {
            // arrange
            IAnimal animal = new AnimalBase();
            animal.Specie = Factory.Enumerators.Species.Wolf;
            animal = animal.Creator();
            var food = new Food();

            // act
            var result = animal.ToEat(food);

            // assert
            Assert.IsTrue(result);
        }
    }
}
