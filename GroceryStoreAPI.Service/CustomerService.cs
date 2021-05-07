using GroceryStoreAPI.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Service
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository customerRepo;

        public CustomerService(ICustomerRepository customerRepository)
        {
            customerRepo = customerRepository;
        }

        public async Task<bool> AddCustomerAsync(Customer customer)
        {
            return await customerRepo.Create(customer);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            return await customerRepo.Update(customer);
        }
         
        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await customerRepo.Delete(id);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await customerRepo.RetrieveAll();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await customerRepo.Retrieve(id);
        }
    }
}
