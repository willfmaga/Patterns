using Factory.Entities.Foods;
using Factory.Interfaces;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Animals
{
    public class Dog : AnimalBase
    {
        public override bool ToEat(IFood food)
        {
            if (food is Food || food is DogFood)
                return base.ToEat(food);
            else
                return false;
                
        }
    }
}
