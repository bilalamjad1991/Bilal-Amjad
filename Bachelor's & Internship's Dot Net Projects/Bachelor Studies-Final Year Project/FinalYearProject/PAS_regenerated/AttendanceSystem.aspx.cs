using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAS_regenerated
{
    public partial class AttendanceSystem : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
 
        }

        protected void btnTimeIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceTimeIn.aspx");
        }

        protected void btnTimeOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("AttendanceTimeOut.aspx");
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            try
            {

                if (Session["username"] != null)
                {
                    if (Session["selection"].ToString() == "3")
                    {
                        Response.Redirect("Cashier.aspx");
                    }

                    else if (Session["selection"].ToString() == "1")
                    {
                        Response.Redirect("AdminPage.aspx");
                    }

                    else if (Session["selection"].ToString() == "2")
                    {
                        Response.Redirect("Bill.aspx");
                    }
                    //Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Redirect("Index.aspx");
                }
                ////////////////////////////////////////////////////////

                //if (Session["selection"].ToString() == "3")
                //{
                //    Response.Redirect("Cashier.aspx");
                //}
                //else if (Session["selection"].ToString() == "2")
                //{
                //    Response.Redirect("Bill.aspx");
                //}
                //else if (Session["selection"].ToString() == "1")
                //{
                //    Response.Redirect("AdminPage.aspx");
                //}

                //else if (Session["selection"] == null)
                //{
                //    Response.Redirect("Index.aspx");
                //}

                //else if (Session["username"] == null)
                //{
                //    Response.Redirect("Index.aspx");
                //}
              
                //else
                //{
                //    Response.Redirect("Index.aspx");
 
                //}
           
            }
            catch(Exception ex)
            {
                //Response.Redirect("Index.aspx");
                ex.ToString();
                
            }
        }
    }
}