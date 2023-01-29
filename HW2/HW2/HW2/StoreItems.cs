using System;
using Newtonsoft.Json;

namespace HW2
{
    public class StoreItems
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public double Cost { get; set; }

        public StoreItems(int id, string name, string description, string category, double cost)
        {
            Id = id;
            Name = name;
            Description = description;
            Category = category;
            Cost = cost;

        }
        public StoreItems() { }
    }
}

