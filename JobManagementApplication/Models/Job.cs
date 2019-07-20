using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.Models
{
    public class Job
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CustomerID { get; set; }
        public bool IsFinished { get; set; }
        public bool DepositMade { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateFinished { get; set; }
        public decimal Worth { get; set; }
        public string convDepositMade { get; set; }
        public string convIsFinished { get; set; }
    }
}
