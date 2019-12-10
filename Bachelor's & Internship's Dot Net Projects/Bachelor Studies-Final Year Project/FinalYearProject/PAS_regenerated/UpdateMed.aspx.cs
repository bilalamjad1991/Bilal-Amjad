using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PAS_regenerated
{
    public partial class UpdateMed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    gdRows.DataBind();
            //}
            if (Session["username"] != null)
            {
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }

                else if (Session["selection"].ToString() == "1")
                {
                    lnkbtnRegister.Visible = true;
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
        }



        protected void lnkbtnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changePassword.aspx");
        }

        protected void lnkbtnSignout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Index.aspx");
        }

        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void SqlDataSource1_Updated(object sender, SqlDataSourceStatusEventArgs e)
        {
            if (e.Exception != null)
            {
                //Show error message
                lblNoRecords.Text = "Medicine not found";
             
                //Set the exception handled property so it doesn't bubble-up
                e.ExceptionHandled = true;
            }
        }

        protected void gdRows_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gdRows.Rows[e.RowIndex];
                
                string tr = ((TextBox)(row.Cells[4].Controls[0])).Text; //unit price
            //    row.Cells[1].Text = int([row.Cells[1].Text] * -1);
                int v12 = Convert.ToInt32(tr);  //ordered quantity

                if (v12 < 1)
                {
                   
                    //v12 = 1;
                    //row.Cells[4].Text = "1";
                   // ((TextBox)(row.Cells[4].Controls[0])).Text = "1";
                    ((TextBox)gdRows.Rows[e.RowIndex].Cells[4].Controls[0]).Text = "1";

                }
               

            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }
                else if (Session["selection"].ToString() == "2")
                {
                    Response.Redirect("Bill.aspx");
                }
                else if (Session["selection"].ToString() == "1")
                {
                    Response.Redirect("AdminPage.aspx");
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                //Response.Redirect("Index.aspx");
                ex.ToString();

            }
        }
    }
}