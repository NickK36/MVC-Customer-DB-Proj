using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobManagementApplication.DAL;
using JobManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApplication.Controllers
{
    public class JobController : Controller
    {
        private ICustomerSqlDAO customerDAO;
        private IJobSqlDAO jobDAO;

        public JobController(ICustomerSqlDAO customerDAO, IJobSqlDAO jobDAO)
        {
            this.customerDAO = customerDAO;
            this.jobDAO = jobDAO;
        }
        [HttpGet]
        public IActionResult AddJob(int ID)
        {
            JobCustomerVM vm = new JobCustomerVM();
            vm.Customer = customerDAO.GetCustomerByID(ID);
            // vm.Job.CustomerID = ID;
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddJob(Job job)
        {
                jobDAO.CreateJob(job.Title, job.Description, job.CustomerID, job.DepositMade, job.Worth);
                return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public IActionResult ViewJobs(int ID)
        {
            IList<Job> jobList = jobDAO.GetJobs(ID);

            return View(jobList);
        }

        [HttpGet]
        public IActionResult Detail(int ID)
        {
            Job job = jobDAO.GetJob(ID);

            return View(job);
        }
    }
}