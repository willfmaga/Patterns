using Factory.Entities.Foods;
using Factory.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Animals
{
    public class Bird : AnimalBase
    {
        public override string MakeSound()
        {
            return "Piu piu";
        }

        public override bool ToEat(IFood food)
        {
            if (food is BirdFood)
                return base.ToEat(food);
            else
                return false;
        }
    }
}
