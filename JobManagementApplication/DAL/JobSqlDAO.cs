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

                    string sql = $"SELECT * FROM Job WHERE CustomerID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        jobList.Add(RowToObject(reader));
                    }
                    foreach (Job job in jobList)
                    {
                        job.convDepositMade = ConvertBoolToString(job.DepositMade);
                        job.convIsFinished = ConvertBoolToString(job.IsFinished);
                    }
                    return jobList;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // Allows the user to get a single job by ID to display the detail page
        public Job GetJob(int ID)
        {
            Job job = new Job();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"SELECT * FROM Job WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", ID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        job = RowToObject(reader);
                    }
                        job.convDepositMade = ConvertBoolToString(job.DepositMade);
                        job.convIsFinished = ConvertBoolToString(job.IsFinished);
                    return job;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }


        // Allows the user to create a new job linked to a customer by ID
        public void CreateJob(string jobTitle, string jobDescription, int customerID, bool depositMade, decimal worth)
        {
            Job newJob = new Job();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO Job (JobTitle, JobDescription, CustomerID, Finished, DepositPayed, DateStarted, Worth)" +
                        $"                  VALUES (@jobTitle, @jobDescription, @customerID, 0, @depositMade, @dateStarted, @worth);";
                    DateTime dateNow = DateTime.Now;
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@jobTitle", jobTitle);
                    cmd.Parameters.AddWithValue("@jobDescription", jobDescription);
                    cmd.Parameters.AddWithValue("@customerID", customerID);
                    cmd.Parameters.AddWithValue("@depositMade", depositMade);
                    cmd.Parameters.AddWithValue("@dateStarted", dateNow);
                    //if (worth != null || worth != 0)
                    //{
                        cmd.Parameters.AddWithValue("@worth", worth);
                    //}
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public string ConvertBoolToString(bool boolValue)
        {
            string convertedBool;

            if (boolValue == true)
            {
                convertedBool = "Yes";
            }
            else if (boolValue == false)
            {
                convertedBool = "No";
            }
            else
            {
                convertedBool = "N/A";
            }
            return convertedBool;
        }

        private Job RowToObject(SqlDataReader reader)
        {
            // Create a customer
            Job obj = new Job();
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Title = Convert.ToString(reader["JobTitle"]);
            obj.Description = Convert.ToString(reader["JobDescription"]);
            obj.CustomerID = Convert.ToInt32(reader["CustomerID"]);
            obj.IsFinished = Convert.ToBoolean(reader["Finished"]);
            obj.DepositMade = Convert.ToBoolean(reader["DepositPayed"]);
            obj.DateStarted = Convert.ToDateTime(reader["DateStarted"]);
            if (!DBNull.Value.Equals(reader["DateFinished"]))
            {
                obj.DateFinished = Convert.ToDateTime(reader["DateFinished"]);
            }
            if (!DBNull.Value.Equals(reader["Worth"]))
            {
                obj.Worth = Convert.ToDecimal(reader["Worth"]);
            }
            else
            {
                obj.Worth = 0;
            }
            return obj;
        }
    }
}