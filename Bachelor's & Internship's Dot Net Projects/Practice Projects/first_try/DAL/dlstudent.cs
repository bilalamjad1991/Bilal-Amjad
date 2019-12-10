using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Student;
using System.Data.SqlClient;
namespace DAL
{
    public class dlstudent
    {
        
        
            public List<firstyear> ListStudent()
            {
                List<firstyear> allStudents = new List<firstyear>();
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Data Source=127.0.0.1;Initial Catalog=Student;User ID=sa;password=123";
                SqlCommand cmd = new SqlCommand("SELECT * FROM SDetail");
                cmd.Connection = con;
                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        firstyear record = new firstyear();
                        record.StudentID = Convert.ToInt32(reader[0]);
                        record.FirstName = Convert.ToString(reader["FName"]);
                        
                        record.LastName = Convert.ToString(reader["LName"]);
                       
                        allStudents.Add(record);
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
                return allStudents;
            }
        }
    }

