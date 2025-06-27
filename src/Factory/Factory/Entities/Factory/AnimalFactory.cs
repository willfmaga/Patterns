using Factory.Entities.Animals;
using Factory.Enumerators;
using Factory.Interfaces;

namespace Factory.Entities.Factory
{
    public class AnimalFactory
    {
        public static IAnimal Create(Species specie)
        {
            switch (specie)
            {
                case Species.Cat:
                    return new Cat();
                case Species.Wolf:
                    return new Wolf();
                case Species.Bird:
                    return new Bird();
                case Species.Dog:
                    return new Dog();
                default:
                    throw new ArgumentException("Unknown animal type");
            }
        }
    }
}
