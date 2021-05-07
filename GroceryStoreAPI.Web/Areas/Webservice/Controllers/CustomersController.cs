using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryStoreAPI.Core;
using GroceryStoreAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace GroceryStoreAPI.Web.Areas.Webservice.Controllers
{
    public class CustomersController : Controller
    {
        ICustomerService customers;

        public CustomersController(ICustomerService customerService)
        {
            customers = customerService;
        }

        public async Task<IActionResult> GetAll()
        { 
            List<Customer> allCustomers = await customers.GetAllCustomersAsync();

            return Json(allCustomers);
        }

        public async Task<IActionResult> Add(string name)
        {  
            bool didAdd = await customers.AddCustomerAsync(new Customer(name));

            return Json(didAdd);
        }

        public async Task<IActionResult> Update(int id, string name)
        {
            var customer = new Customer(name);
            customer.Id = id;

            bool didUpdate = await customers.UpdateCustomerAsync(customer);

            return Json(didUpdate);
        }

        public async Task<IActionResult> Delete(int id)
        {
            bool didDelete = await customers.DeleteCustomerAsync(id);

            return Json(didDelete);
        }
    }
}
