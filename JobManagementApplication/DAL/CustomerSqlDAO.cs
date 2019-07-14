using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.Models
{
    public class CustomerSqlDAO : ICustomerSqlDAO
    {
        private readonly string connectionString;

        public CustomerSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Customer GetCustomerByID(int ID)
        {
            Customer customer = new Customer();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Customer WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        customer = RowToObject(reader);
                    }
                    return customer;
                }
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public IList<Customer> GetCustomers()
        {
            List<Customer> customerList = new List<Customer>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM Customer ORDER BY LastName asc, FirstName asc";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a city
                        Customer customer = RowToObject(reader);
                        customerList.Add(customer);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return customerList;
        }

        private Customer RowToObject(SqlDataReader reader)
        {
            // Create a customer
            Customer obj = new Customer();
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.FirstName = Convert.ToString(reader["FirstName"]);
            obj.LastName = Convert.ToString(reader["LastName"]);
            obj.Address = Convert.ToString(reader["Address"]);
            obj.City = Convert.ToString(reader["City"]);
            obj.PhoneNumber = Convert.ToString(reader["PhoneNumber"]);
            return obj;
        }

    }
}
