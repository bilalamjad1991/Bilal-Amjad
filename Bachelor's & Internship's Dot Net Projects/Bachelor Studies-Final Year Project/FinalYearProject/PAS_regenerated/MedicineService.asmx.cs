using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PAS_regenerated
{
    /// <summary>
    /// Summary description for MedicineService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class MedicineService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetMedicineNames(string medicineName)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<string> medicineNames = new List<string>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchingMedicineNames", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@MedicineName", medicineName);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    medicineNames.Add(rdr["ProductName"].ToString());
                }

            }
            return medicineNames;
        }
    }
}
