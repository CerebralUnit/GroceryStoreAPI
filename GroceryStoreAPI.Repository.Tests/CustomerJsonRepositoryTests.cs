using System;
using Xunit;
using GroceryStoreAPI.Repository;
using GroceryStoreAPI.Core;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Generic;

namespace GroceryStoreAPI.Repository.Tests
{
    public class CustomerJsonRepositoryTests
    {
        /*
            On create and update methods, we're checking that the json string
            was updated by MANUALLY deserializing and pulling out customer objects
            because we don't want to create a dependency on another (potentially broken) 
            method in the Repository class. 
        */

        [Fact]
        public async Task Retrieve_Returns_Valid_Customer()
        {
            int expectedCustomerId = 1;
            string expectedCustomerName = "Lorem";

            var jsonContextMock = new MockJsonRepositoryContext();
            var customerRepo = new CustomerJSONRepository(jsonContextMock);

            Customer customer = await customerRepo.Retrieve(expectedCustomerId);

            Assert.NotNull(customer);
            Assert.IsAssignableFrom<Customer>(customer);
            Assert.Equal(expectedCustomerName, customer.Name);
        }

        [Fact]
        public async Task Create_Increments_Customer_Id()
        {
            int highestCustomerId = 3;
            int incrementer = 1;
              
            var jsonContextMock = new MockJsonRepositoryContext();
            var customerRepo = new CustomerJSONRepository(jsonContextMock);

            var customer = new Customer("Sit");
             
            await customerRepo.Create(customer);
             
            Assert.Equal(customer.Id, highestCustomerId + incrementer);
        }

        [Fact]
        public async Task Create_Saves_New_Customer()
        {
            var jsonContextMock = new MockJsonRepositoryContext();

            var customerRepo = new CustomerJSONRepository(jsonContextMock);

            var customer = new Customer("Sit");

            await customerRepo.Create(customer);

            CustomerListDTO updatedObject = JsonConvert.DeserializeObject<CustomerListDTO>(jsonContextMock.mockJson);

            var updatedCustomer = updatedObject.Customers.FirstOrDefault(c => c.Id == customer.Id && c.Name == customer.Name);

            Assert.NotNull(updatedCustomer);
        }

        [Fact]
        public async Task RetrieveAll_Retrieves_All_Customers()
        {
            int expectedCount = 3;
            string[] expectedCustomerNames = { "Lorem", "Ipsum", "Dolor" };
          
            var jsonContextMock = new MockJsonRepositoryContext();

            var customerRepo = new CustomerJSONRepository(jsonContextMock);
 
            List<Customer> customers = await customerRepo.RetrieveAll();
             
            Assert.NotNull(customers);

            Assert.Equal(customers.Count, expectedCount);

            for (int i = 0; i < expectedCustomerNames.Length; i++) 
                Assert.Equal(customers.ElementAt(i).Name, expectedCustomerNames[i]); 
        }

        [Fact]
        public async Task Update_Saves_New_Customer()
        {
            string newName = "Jim";

            var customer = new Customer(newName);

            //We will change Lorem's name
            customer.Id = 1;

            var jsonContextMock = new MockJsonRepositoryContext();

            var customerRepo = new CustomerJSONRepository(jsonContextMock);

            await customerRepo.Update(customer);
             
            CustomerListDTO updatedObject = JsonConvert.DeserializeObject<CustomerListDTO>(jsonContextMock.mockJson);

            var updatedCustomer = updatedObject.Customers.FirstOrDefault(c => c.Id == customer.Id);
             
            Assert.NotNull(updatedCustomer);  
        }
    }
}
 