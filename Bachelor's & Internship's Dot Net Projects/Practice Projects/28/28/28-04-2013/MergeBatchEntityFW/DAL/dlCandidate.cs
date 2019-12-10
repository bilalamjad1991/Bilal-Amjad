using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using System.Data.SqlClient;

namespace DAL
{
    public class dlCandidate
    {
        public List<Candidates> ListCandidates()
        {
            List<Candidates> allCandidates = new List<Candidates>();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=MergeBatch;";//User ID=sa;password=123
            SqlCommand cmd = new SqlCommand("SELECT * FROM CANDIDATES");
            cmd.Connection = con;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Candidates record = new Candidates();
                    record.CandidateID = Convert.ToInt32(reader[0]);
                    record.FirstName = Convert.ToString(reader["FirstName"]);
                    record.MiddleName = Convert.ToString(reader["MiddleName"]);
                    record.LastName = Convert.ToString(reader["LastName"]);
                    record.YearsExperience = Convert.ToInt32(reader["YearsExperience"]);
                    //record.CVPath = Convert.ToString(reader["CVPath"]);
                    allCandidates.Add(record);
                }
                con.Close();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return allCandidates;
        }
    }
}
