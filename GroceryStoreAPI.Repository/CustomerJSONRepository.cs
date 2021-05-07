using GroceryStoreAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Repository
{
    public class CustomerJSONRepository : BaseJSONRepository<CustomerListDTO>, ICustomerRepository
    {
        public CustomerJSONRepository(IJsonRepositoryContext context) : base(context) { }

        //added an unsophisticated auto-incrementer for Id since we're emulating a database
        public async Task<bool> Create(Customer obj)
        {
            CustomerListDTO customerList = await RetrieveObjectAsync();

            int highestDataId = customerList.Customers.Max(c => c.Id.Value);

            obj.Id = highestDataId + 1;

            customerList.Customers.Add(obj);

            return await SaveObjectAsync(customerList);
        }

        public async Task<bool> Delete(int primaryKey)
        { 
            bool didSave = false;

            CustomerListDTO customerList = await RetrieveObjectAsync();
 
            if (customerList.Customers.Any(c => c.Id == primaryKey))
            {
                customerList.Customers.RemoveAll(c => c.Id == primaryKey);
                didSave = await SaveObjectAsync(customerList); 
            }

            return didSave;
        }

        public async Task<Customer> Retrieve(int primaryKey)
        { 
            CustomerListDTO customerList = await RetrieveObjectAsync();

            Customer customer = customerList
                                    .Customers
                                    .FirstOrDefault(c => c.Id == primaryKey);
             
            return customer;
        }

        public async Task<List<Customer>> RetrieveAll()
        {
            CustomerListDTO customerList = await RetrieveObjectAsync();
            List<Customer> customers = null;
            
            if (customerList != null)
                customers = customerList.Customers;

            return customers; 
        }
 
        public async Task<bool> Update(Customer obj)
        { 
            CustomerListDTO customerList = await RetrieveObjectAsync();

            Customer matchingRecord = customerList
                                    .Customers
                                    .FirstOrDefault(c => c.Id == obj.Id);

            matchingRecord.Name = obj.Name;

            return await SaveObjectAsync(customerList); 
        }
    }
}
