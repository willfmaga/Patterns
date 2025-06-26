using Factory.Entities.Animals;
using Factory.Entities.Foods;
using Factory.Interfaces;

namespace Factory.Extensions
{
    public static class AnimalExtensions
    {
        public static IAnimal Factory(this IAnimal animal)
        {
            switch (animal.Specie)
            {
                case Enumerators.Species.Dog:
                    return new Dog();
                case Enumerators.Species.Cat:
                    return new Cat();
                case Enumerators.Species.Bird:
                    return new Bird();
                case Enumerators.Species.Wolf:
                    return new Wolf();
                default:
                    return new AnimalBase();
            }
        }
    }
}
