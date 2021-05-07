using GroceryStoreAPI.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Service 
{
    public interface ICustomerService
    {
        Task<bool> AddCustomerAsync(Customer customer);

        Task<Customer> GetCustomerAsync(int id);

        Task<bool> DeleteCustomerAsync(int id);

        Task<List<Customer>> GetAllCustomersAsync();

        Task<bool> UpdateCustomerAsync(Customer customer);
    }
}
