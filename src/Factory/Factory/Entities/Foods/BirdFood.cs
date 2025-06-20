using Factory.Interfaces;


namespace Factory.Entities.Foods
{
    public class BirdFood: IFood
    {
        public string Name { get; set; } = "Bird Food";
        public string Description { get; set; } = "Food for birds, rich in seeds and nutrients.";
    }
}
