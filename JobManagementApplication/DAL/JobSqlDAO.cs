using JobManagementApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace JobManagementApplication.DAL
{
    public class JobSqlDAO : IJobSqlDAO
    {

        private readonly string connectionString;

        public JobSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Gets a job from a particular customer
        public IList<Job> GetJobs(int ID)
        {
            IList<Job> jobList = new List<Job>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Jobs WHERE CustomerID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        jobList.Add(RowToObject(reader));
                    }
                    return jobList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // Allows the user to create a new job linked to a customer by ID
        public void CreateJob(string jobTitle, string jobDescription, int customerID, bool depositMade)
        {
            Job newJob = new Job();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO Job (JobTitle, JobDescription, CustomerID, Finished, DepositPayed, DateStarted)" +
                        $"                  VALUES (@jobTitle, @jobDescription, @customerID, 0, @depositMade, @dateStarted);";
                    DateTime dateNow = DateTime.Now;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                    cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@depositMade", depositMade);
                    cmd.Parameters.AddWithValue("@dateStarted", dateNow);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        private int BoolToBit(bool boolean)
        {
            int result = 0;
            if (boolean)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }
        private Job RowToObject(SqlDataReader reader)
        {
            // Create a customer
            Job obj = new Job();
            obj.Title = Convert.ToString(reader["JobTitle"]);
            obj.Description = Convert.ToString(reader["JobDescription"]);
            obj.CustomerID = Convert.ToInt32(reader["CustomerID"]);
            obj.IsFinished = Convert.ToBoolean(reader["Finished"]);
            obj.DepositMade = Convert.ToBoolean(reader["DepositPayed"]);
            obj.DateStarted = Convert.ToDateTime(reader["DateStarted"]);
            obj.DateFinished = Convert.ToDateTime(reader["DateFinished"]);
            return obj;
        }
    }
}