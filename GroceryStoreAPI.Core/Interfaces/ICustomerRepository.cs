using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryStoreAPI.Core
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
