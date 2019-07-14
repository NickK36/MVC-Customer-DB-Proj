using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApplication.Controllers
{
    public class CustomerController : Controller
    {
        #region Controller & Home Page (Index)
        private ICustomerSqlDAO customerDAO;

        public CustomerController(ICustomerSqlDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }

        public IActionResult Index()
        {
            IList<Customer> customerList = customerDAO.GetCustomers();
            return View(customerList);
        }
        #endregion

        public IActionResult Detail(int ID)
        {
            Customer customer = customerDAO.GetCustomerByID(ID);
            return View(customer);
        }
    }
}