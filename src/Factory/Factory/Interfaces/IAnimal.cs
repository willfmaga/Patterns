using Factory.Enumerators;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Interfaces
{
    public interface IAnimal
    {
        Species Specie { get; set; }
        string MakeSound();

        bool ToEat(IFood food);
        
    }
}
