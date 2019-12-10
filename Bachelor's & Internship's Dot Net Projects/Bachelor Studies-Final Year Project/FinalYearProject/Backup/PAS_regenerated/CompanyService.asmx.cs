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
    /// Summary description for CompanyService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class CompanyService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetCompanyNames(string CompanyName)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            List<string> CompanyNames = new List<string>();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("spGetMatchingCompanyNames", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter = new SqlParameter("@CompanyName", CompanyName);
                cmd.Parameters.Add(parameter);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    CompanyNames.Add(rdr["P_Company"].ToString());
                }

            }
            return CompanyNames;
        }
    }
}
