using Factory.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.Entities.Foods
{
    public class CatFood : IFood
    {
        public string Name { get; set; } = "Cat Food";
        public string Description { get; set; } = "Food for cats, rich in proteins and vitamins.";
       
    }
}
