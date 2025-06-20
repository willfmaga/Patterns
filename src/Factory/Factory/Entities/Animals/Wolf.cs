using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Animals
{
    public class Wolf : AnimalBase
    {
        public override string MakeSound()
        {
            var sound = base.MakeSound();

            return sound += " Auuuuuuu";
        }
    }
}
