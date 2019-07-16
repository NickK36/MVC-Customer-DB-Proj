using JobManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.DAL
{
    public interface IJobSqlDAO
    {
        IList<Job> GetJobs(int ID);

        void CreateJob(string jobTitle, string jobDescription, int customerID, bool depositMade);
    }
}
