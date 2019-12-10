using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Text;
namespace PAS_regenerated
{
    public partial class Cashier : System.Web.UI.Page
    {
      
        string cs=ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] == null)
            //{
            //    Response.Redirect("Index.aspx");
            //}


            if (Session["username"] != null)
            {
                if (Session["selection"].ToString() == "2")
                {
                    Response.Redirect("Bill.aspx");
                }

                else if (Session["selection"].ToString() == "1")
                {
                    Response.Redirect("AdminPage.aspx");

                }
                //Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }
           
            txtInvoiceNumber.Focus();

        }

      

        protected void btnCheck_Click(object sender, EventArgs e)
        {
          
            this.checkBill();
            this.headerText();
         
        }

        private void calculateGrandToral()
        {
            decimal aaa, bbb = 0;
            for (int j = 0; j < (GridView1.Rows.Count); j++)
            {
                aaa = Convert.ToDecimal(GridView1.Rows[j].Cells[3].Text.ToString());
                bbb = bbb + aaa; //storing total qty into variable 
                GridView1.FooterRow.Cells[3].Text = bbb.ToString();
                GridView1.FooterRow.Cells[2].Text = "Grand Total = ";
            }

            txtNetAmount.Text = GridView1.FooterRow.Cells[3].Text;
          
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
           
         
            try
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "printing();", true);
                txtInvoiceNumber.Text = "";
                txtInvoiceNumber.Focus();
             //   txtReturned.Text = Convert.ToString(Convert.ToDouble(txtPaid.Text) - Convert.ToDouble(txtNetAmount.Text));
            }

            catch(Exception exx)
            {
                exx.ToString();
            }
         

          

          
        }

        public void checkBill()
        {
            try
            {

                SqlConnection conn = new SqlConnection(cs);
                string strsql = "SELECT ProductName,P_Price,P_OrderQty,P_Total from Invoice where InvoiceNumber='" + txtInvoiceNumber.Text.Trim() + "' ";
                SqlDataAdapter dr = new SqlDataAdapter(new SqlCommand(strsql, conn));
                DataTable dt = new DataTable();
                conn.Open();
                dr.Fill(dt);
                conn.Close();
                ///////////////////////////////////////////////////////
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();


                cmd.CommandText = "SELECT InvoiceNumber from Invoice where InvoiceNumber='" + txtInvoiceNumber.Text.Trim() + "' ";
                cmd.Connection = con;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                  lblInvoicenumber.Text= "Invoice # "+Convert.ToString( rdr[0]);
                    rdr.Close();
                    con.Close();
 
                }


                
                ViewState["temp"] = dt;   // storing datatable value in viewstate
                if (dt.Rows.Count<1)
                {
                    lblInvoiceStatus.Visible = true;
                    lblDate.Visible = false;
                    lblInvoicenumber.Visible = false;
                    lblInvoiceStatus.Text = "No data exist";
                    btnPrint.Visible = false;
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();
                    lblNetAmt.Visible = false;
                    txtNetAmount.Visible = false;

                    lblPaid.Visible = false;
                    txtPaid.Visible = false;

                    lblReturned.Visible = false;
                    txtReturned.Visible = false;
                }
                else
                {

                    txtPaid.Text = "";
                    txtReturned.Text = "";
                    lblInvoiceStatus.Visible = false;

                    lblInvoicenumber.Visible = true;
                    lblDate.Visible = true;
                    lblDate.Text = "Date & Time : " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    
                    this.GridView1.DataSource = dt;
                    this.GridView1.DataBind();

                    btnPrint.Visible = true;
                    btnClearBill.Visible = true;

                    lblNetAmt.Visible = true;
                    txtNetAmount.Visible = true;

                   
                    lblPaid.Visible = true;
                    txtPaid.Visible = true;
                  

                    lblReturned.Visible = true;
                    txtReturned.Visible = true;
                   
                    this.calculateGrandToral();
                   
                  
                }
            }
            catch(Exception ex)
            {
                lblInvoiceStatus.Visible = true;
                lblInvoiceStatus.Text = "Incorrect entry";
                lblInvoicenumber.Visible = false;
                lblDate.Visible = false;
                btnPrint.Visible = false;
                btnClearBill.Visible = false;
                lblNetAmt.Visible = false;
                txtNetAmount.Visible = false;

                lblPaid.Visible = false;
                txtPaid.Visible = false;

                lblReturned.Visible = false;
                txtReturned.Visible = false;
                this.GridView1.DataSource = null;
                this.GridView1.DataBind();
                ex.ToString();

            }
        }

        protected void headerText()
        {
            if (GridView1.Rows.Count > 0)
            {
                GridView1.HeaderRow.Cells[0].Text = " Product Name ";
                GridView1.HeaderRow.Cells[1].Text = " Unit Price ";
                GridView1.HeaderRow.Cells[2].Text = " Order Quantity ";
                GridView1.HeaderRow.Cells[3].Text = " Total ";
            }
 
        }

        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;
        //    //DataTable dtt = ViewState["CurrentData"] as DataTable;
        //    //DataTable dt = ViewState["temp"] as DataTable;
        //    //GridView1.DataSource = dt;
        //    //GridView1.DataBind();
        //    this.BindGrid1();
        //    this.headerText();
        //    this.calculateGrandToral();
        //}

        private void BindGrid1()
        {
            DataTable dt = ViewState["temp"] as DataTable;
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           // Label1.Text = DropDownList1.SelectedItem.Text;
       //     Label1.Text = DropDownList1.SelectedIndex.ToString();
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

     

        protected void txtPaid_TextChanged(object sender, EventArgs e)
        {
            txtReturned.Text = Convert.ToString(Convert.ToDouble(txtPaid.Text) - Convert.ToDouble(txtNetAmount.Text));
            
        }

        protected void btnClearBill_Click(object sender, EventArgs e)
        {
            lblDate.Visible = false;
            lblInvoicenumber.Visible = false;
            lblInvoiceStatus.Visible = false;
            btnPrint.Visible = false;
         
            lblNetAmt.Visible = false;
            txtNetAmount.Visible = false;

            lblPaid.Visible = false;
            txtPaid.Visible = false;

            lblReturned.Visible = false;
            txtReturned.Visible = false;


            GridView1.DataSource = null;
            GridView1.DataBind();
            btnClearBill.Visible = false;
            txtInvoiceNumber.Text = "";
            txtInvoiceNumber.Focus();
        }

        protected void lnkbtnHome_Click(object sender, EventArgs e)
        {
            if (Session["selection"].ToString() == "3")
            {
                Response.Redirect("Cashier.aspx");
            }
            else if (Session["selection"].ToString() == "2")
            {
                Response.Redirect("Bill.aspx");
            }
            else
            {
                Response.Redirect("AdminPage.aspx");
            }
        }

        
    }
}