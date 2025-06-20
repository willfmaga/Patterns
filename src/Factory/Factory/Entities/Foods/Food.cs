using Factory.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Foods
{
    public class Food :IFood
    {
        public string Name { get; set; } = "Generic Food for Dogs, Cats or Wolfs";
        public string Description { get; set; } = "Generic food for those animals: Dogs, Cats or Wolfs";
    }
}
