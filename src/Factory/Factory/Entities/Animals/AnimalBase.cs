using Factory.Entities.Foods;
using Factory.Enumerators;
using Factory.Interfaces;

namespace Factory.Entities.Animals
{
    public class AnimalBase : IAnimal
    {
        public Species Specie { get; set; }

        public virtual string MakeSound()
        {
            return "Au au au";
        }

        public virtual bool ToEat(IFood food)
        {
            if (food is not null)
                return true;
            return false;
        }
    }
}
