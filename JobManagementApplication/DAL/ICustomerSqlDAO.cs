using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.Models
{
    public interface ICustomerSqlDAO
    {
        IList<Customer> GetCustomers();

        Customer GetCustomerByID(int ID);
    }
}
