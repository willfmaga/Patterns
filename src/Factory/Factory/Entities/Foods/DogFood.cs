using Factory.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Foods
{
    public class DogFood : IFood
    {
        public string Name { get; set; } = "Dog Food";
        public string Description { get; set; } = "Food for dogs, rich in proteins and vitamins.";
    }
}
