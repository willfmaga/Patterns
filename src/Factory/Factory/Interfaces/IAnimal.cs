using Factory.Enumerators;

namespace Factory.Interfaces
{
    public interface IAnimal
    {
        string eyesColor { get; set; }
        Species Specie { get; set; }
        string MakeSound();
        
    }
}
