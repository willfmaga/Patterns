using Factory.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Animals
{
    public class Cat : AnimalBase
    {

        public override string MakeSound()
        {
            return "Miau miau";
        }

        
    }
}
