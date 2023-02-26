using System;
namespace HWK4.Models
{
    public class Storeitems
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Category { get; set; } = String.Empty;
        public bool IsCompleted { get; set; } 
        public int Amount { get; set; }

        public Storeitems( string Item, string Fruit, string vegetable, int amount)
        {
            
            Name = Item;
            Description = Fruit;
            Category = vegetable;
            IsCompleted= true;
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
