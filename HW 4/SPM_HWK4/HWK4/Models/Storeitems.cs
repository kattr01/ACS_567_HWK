using System;
namespace HWK4.Models
{
    public class Storeitems
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public int Amount { get; set; }

        public Storeitems(int id, string Item, string Fruit, string vegetable, int amount)
        {
            Id = id;
            Name = Item;
            Description = Fruit;
            Category = vegetable;
            Amount = amount;

        }

        public Storeitems() { }
    }
    public class Todo
    {
        public string Description { get; set; } = String.Empty;

        public bool IsCompleted { get; set; } = false;

        public int Id { get; set; }
    }
}
