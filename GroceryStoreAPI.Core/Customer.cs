using System;

namespace GroceryStoreAPI.Core
{
    public class Customer
    {
        public Customer() { }
        
        public Customer(string name)
        {
            this.Name = name;
        }

        public int? Id { get; set; }
        public string Name { get; set; }
    }
}
