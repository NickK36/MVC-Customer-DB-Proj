using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.Models
{
    public class JobCustomerVM
    {
        public Customer Customer { get; set; }
        public Job Job { get; set; }
    }
}
