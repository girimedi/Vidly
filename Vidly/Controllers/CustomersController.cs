using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.ViewModels;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customerList = new CustomerListViewModel()
            {
                CustomerList = new List<Customer>()
                {
                    new Customer (){Id= 1, Name ="Customer1"},
                    new Customer (){Id = 2,Name = "Customer2"}
                }
            };


            return View(customerList);
        }

        public ActionResult CustomerDetails(int Id, CustomerListViewModel customerListViewModel )
        {
            List<Customer> customers = customerListViewModel.CustomerList;
            Customer selectedCustomer = customers.Find(x => x.Id == Id);
            return View(selectedCustomer);
        }
    }
}