using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; 
using GroceryStoreAPI.Service;
using GroceryStoreAPI.Core;

namespace GroceryStoreAPI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ICustomerService customers;

        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;

            customers = customerService;
        }

        public async Task<IActionResult> Index()
        { 
            ViewBag.Customers = await customers.GetAllCustomersAsync();
            
            return View();
        } 
    }
}
