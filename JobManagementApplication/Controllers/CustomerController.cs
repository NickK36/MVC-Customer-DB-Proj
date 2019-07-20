using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagementApplication.DAL;
using JobManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApplication.Controllers
{
    public class CustomerController : Controller
    {
        #region Controller & Home Page (Index)
        private ICustomerSqlDAO customerDAO;
        private IJobSqlDAO jobDAO;

        public CustomerController(ICustomerSqlDAO customerDAO, IJobSqlDAO jobDAO)
        {
            this.customerDAO = customerDAO;
            this.jobDAO = jobDAO;
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