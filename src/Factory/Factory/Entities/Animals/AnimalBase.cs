using Factory.Enumerators;
using Factory.Interfaces;

namespace Factory.Entities.Animals
{
    public abstract class AnimalBase : IAnimal
    {
        public Species Specie { get; set; }
        public string eyesColor { get; set;}

        public virtual string MakeSound()
        {
            //alterar o saldo da conta titular 

            return "Au au au";
        }
    }
}
