using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Configuration;

namespace PAS_regenerated
{
    public partial class Bill : System.Web.UI.Page
    {
        string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        bool flag = true;
        string  unit,stock, salt;
     //   float  = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                if (Session["selection"].ToString() == "3")
                {
                    Response.Redirect("Cashier.aspx");
                }

                else if (Session["selection"].ToString() == "1")
                {
                    lnkbtnRegister.Visible = true;
                    lnkbtnRegister.Enabled = true;
                }
                //Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("Index.aspx");
            }

            txtMedicineName.Focus();
           // txtMedicineName.Text = "";
            this.InvoiceData();
            //Label1.Visible = true;
            //Label1.Text = DateTime.Now.ToString("h:mm:sstt");
            if (!IsPostBack)
            {
                this.BindGrid1();
            }

        }

        private void InvoiceData()
        {
            try
            {
                SqlConnection conI = new SqlConnection(CS);
                SqlCommand cmdI = new SqlCommand();
                cmdI.CommandText = "Select Max(InvoiceNumber)+1 from Invoice";
                cmdI.Connection = conI;
                conI.Open();
                SqlDataReader rdr = cmdI.ExecuteReader();

                if (rdr.Read())
                {
                    if (!rdr.IsDBNull(0))
                    {
                        //TextBox1.Text = rdr.GetString(0);
                        txtInvoice.Text = rdr[0].ToString();

                    }
                    else
                    {
                        txtInvoice.Text = "1";

                    }
                }
                else
                {
                }
            }
            catch(Exception ex)
            {
                ex.ToString();
            }

            
        }
       
         private void BindGrid(int rowcount)
        {
            int x, y, z = 0;
         double temp,temp1,temp2 = 0;
          
         
            DataTable dt = new DataTable();

            DataRow dr;

            dt.Columns.Add(new System.Data.DataColumn("Medicine Name", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Stock Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Unit Price", typeof(float)));
            dt.Columns.Add(new System.Data.DataColumn("Order Qty", typeof(Int32)));
             dt.Columns.Add(new System.Data.DataColumn(" Total ", typeof(float)));
             try
             {
                 SqlConnection con = new SqlConnection(CS);
                 SqlCommand cmd = new SqlCommand();

                 ////////////////////////////////////////////////quantity check
                 SqlCommand cmdm = new SqlCommand();

                 //////////////////////////////////////////////////////////////////////////////////////////////////////

                 cmd.CommandText = "SELECT * FROM Medicines where ProductName='" + txtMedicineName.Text.Trim() + "'";
                 cmd.Connection = con;
                 con.Open();
                 SqlDataReader rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {

                     //txtUnitPrice.Text = rdr[3].ToString();   //unit price
                     //txtStockQty.Text = rdr[4].ToString();   //stockquantity
                     unit = rdr[3].ToString();
                     stock = rdr[4].ToString();

                     con.Close();
                     rdr.Close();
                 }
             }
             catch(Exception exx)
             {
                 exx.ToString();
             }

             if (ViewState["CurrentData"] != null)
             {

                 for (int i = 0; i < rowcount + 1; i++)
                 {

                     dt = (DataTable)ViewState["CurrentData"];

                     if (dt.Rows.Count > 0)
                     {

                         dr = dt.NewRow();

                         dr[0] = dt.Rows[0][0].ToString();



                     }

                 }

            
                 for (int m = 0; m < dt.Rows.Count; m++)
                 {
                     if (txtMedicineName.Text == dt.Rows[m]["Medicine Name"].ToString())
                     {
                       Label3.Text = "";
                       //  Label3.Visible = false;
                         flag = false;
                         lblDuplicate.Visible = true;
                         lblDuplicate.Text = "Duplicate entry ";
                         break;
                      
                     }


                 }

                 if (flag == true)
                 {
                     Label3.Text = "";
                     lblDuplicate.Text = "";
                     dr = dt.NewRow();
                     dr[0] = txtMedicineName.Text;

                   //  dr[1] = txtStockQty.Text;  //stock quantity
                     dr[1] = stock.ToString();
                     dr[2] = unit.ToString();//unitprice
                 //    dr[2] = txtUnitPrice.Text; //unitprice
                     dr[3] = txtOrderQty.Text;


                     temp = Convert.ToDouble( dr[2]);
                     temp1 = Convert.ToDouble(dr[3]);
                     //x = Convert.ToInt32(dr[2]);
                     //y = Convert.ToInt32(dr[3]);
                   
                     //z = x * y;
                     temp2 = temp * temp1;

                     //string ss = Convert.ToString(z);
                     //dr[4] = ss;
                     dr[4] = temp2.ToString();
                     dt.Rows.Add(dr);
 
                 }
                    
          
                 
              

            }

            else
            {

                dr = dt.NewRow();

                dr[0] = txtMedicineName.Text;

                //  dr[1] = txtStockQty.Text;  //stock quantity
                dr[1] = stock.ToString();
                dr[2] = unit.ToString();//unitprice
                //    dr[2] = txtUnitPrice.Text; //unitprice
                dr[3] = txtOrderQty.Text;  //order quantity
               
         
                //x = Convert.ToInt32(dr[2]);
                //y = Convert.ToInt32(dr[3]);
                temp = Convert.ToDouble(dr[2]);
                temp1 = Convert.ToDouble(dr[3]);
                //z = x * y;
                temp2 = temp * temp1;
                //string ss = Convert.ToString(z);
                //dr[4] = ss;
                dr[4] = temp2.ToString() ;
                dt.Rows.Add(dr);
            }
            // If ViewState has a data then use the value as the DataSource

            if (ViewState["CurrentData"] != null)
            {

                GridView1.DataSource = (DataTable)ViewState["CurrentData"];

                GridView1.DataBind();

            }

            else
            {

                // Bind GridView with the initial data assocaited in the DataTable

                GridView1.DataSource = dt;

                GridView1.DataBind();

            }

            // Store the DataTable in ViewState to retain the values

            ViewState["CurrentData"] = dt;



        }


         protected void btnAddtoBill_Click(object sender, EventArgs e)
         {
             try
             {

                 SqlConnection con = new SqlConnection(CS);
                 SqlCommand cmd = new SqlCommand();

                 ////////////////////////////////////////////////quantity check
                 SqlCommand cmdm = new SqlCommand();

                 //////////////////////////////////////////////////////////////////////////////////////////////////////

                 cmd.CommandText = "SELECT * FROM Medicines where ProductName='" + txtMedicineName.Text.Trim() + "'";
                 cmd.Connection = con;
                 con.Open();


                 SqlDataReader rdr = cmd.ExecuteReader();
                 if (rdr.Read())
                 {
                     Label1.Visible = false;
                     //txtUnitPrice.Text = rdr[3].ToString();   //unit price
                     //txtStockQty.Text = rdr[4].ToString();   //stockquantity
                     //txtSalt.Text = rdr[1].ToString();
                     salt = rdr[1].ToString();
                     // con.Close();
                     rdr.Close();

                     cmdm.CommandText = "Select Max(P_Qty) from Medicines where ProductName='" + txtMedicineName.Text.Trim() + "' ";
                     cmdm.Connection = con;
                     SqlDataReader rdrm = cmdm.ExecuteReader();


                     string tempOrder = txtOrderQty.Text;
                     if (tempOrder.Length < 1)
                     {
                         txtOrderQty.Text = "1";
                         string s = txtOrderQty.Text;

                     }
                     int i = Convert.ToInt32(txtOrderQty.Text);  //ordr qty
                     if(i<1)
                     {
                         i = 1;
                         txtOrderQty.Text = "1";
                     }
                     if (rdrm.Read())
                     {
                         int j = Convert.ToInt32(rdrm[0]);    // stock quantity

                         if (i >= j)
                         {
                             Label3.Visible = true;
                             Label3.Text = "Maximum available stock : " +j +" Or ";
                             txtOrderQty.Focus();
                             rdrm.Close();
                             con.Close();
                             //DropDownList1.Visible = true;
                             //Button1.Visible = true;
                             txtOrderQty.Text = "";
                             DropDownList1.Items.Clear();
                             this.alternateMedicine();
                         }

                         else
                         {
                             Label3.Visible = false;
                             //Button1.Visible = false;
                             DropDownList1.Visible = false;
                             btnSaveGrid.Visible = true;
                             // label.text=rdrm[0];
                             //btnPrintAll.Visible = true;
                             //btnExportToPDF.Visible = true;

                             if (ViewState["CurrentData"] != null)
                             {

                                 DataTable dt = (DataTable)ViewState["CurrentData"];
                                 int count = dt.Rows.Count;
                                 BindGrid(count);
                             }


                             else
                             {
                                 BindGrid(1);
                             }

                             rdrm.Close();
                             con.Close();

                         }
                     }
                     else
                     {

                     }


                 }
                 else
                 {
                     Label1.Visible = true;
                     Label1.Text = "Medicine Does not Exist";
                     txtMedicineName.Focus();
                     btnSaveGrid.Visible = false;
                     //btnPrintAll.Visible = false;
                     //btnExportToPDF.Visible = false;
                     con.Close();
                 }
                 this.calculateGrandToral();
                 //DropDownList1.Items.Clear();
             }
             catch(Exception ex)
             {
                 ex.ToString();
                 Label1.Visible = true;
                 Label1.Text = "Incorrect Entry";
             }
         }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                lblDuplicate.Visible = false;
                DataTable dtt = ViewState["CurrentData"] as DataTable;
                dtt.Rows.RemoveAt(e.RowIndex);
                GridView1.DataSource = dtt;
                GridView1.DataBind();
                if (dtt.Rows.Count < 1)
                {
                    btnSaveGrid.Visible = false;
                    txtOrderQty.Text = "";
                    txtMedicineName.Text = "";
                    txtMedicineName.Focus();

                }
                this.calculateGrandToral();
                txtOrderQty.Text = "";
                txtMedicineName.Text = "";
                txtMedicineName.Focus();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
         }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridView1.PageIndex = e.NewPageIndex;
                DataTable dtt = ViewState["CurrentData"] as DataTable;
                GridView1.DataSource = dtt;
                GridView1.DataBind();
                this.calculateGrandToral();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
         }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                lblDuplicate.Visible = false;
                GridView1.EditIndex = e.NewEditIndex;
                DataTable dt1 = ViewState["CurrentData"] as DataTable;
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
                      
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                lblDuplicate.Visible = false;
                GridView1.EditIndex = -1;
                DataTable dt1 = ViewState["CurrentData"] as DataTable;
                GridView1.DataSource = dt1;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                lblDuplicate.Visible = false;
                DataTable dt = ViewState["CurrentData"] as DataTable;
                //Update the values.
                int i = e.RowIndex;
                GridViewRow row = GridView1.Rows[e.RowIndex];

                string tr = ((TextBox)(row.Cells[4].Controls[0])).Text; //ordered quantity

                int v12 = Convert.ToInt32(tr);  //ordered quantity
                if (v12 < 1)
                {
                    v12 = 1;
                    //row.Cells[4].Text = "1";
                    ((TextBox)(row.Cells[4].Controls[0])).Text = "1";
                }
                //string f = txtStockQty.Text;
                string f = ((TextBox)(row.Cells[2].Controls[0])).Text;
                int y = Convert.ToInt32(f);  //stock quantity
                if (v12 >= y)     // order quantity >= stock quantity
                {

                    dt.Rows[row.DataItemIndex]["Order Qty"] = f;   //order = stock max quantity
                }
                else
                {
                    dt.Rows[row.DataItemIndex]["Order Qty"] = ((TextBox)(row.Cells[4].Controls[0])).Text;
                }


                //Reset the edit index.
                GridView1.EditIndex = -1;
                //Bind data to the GridView control.
                GridView1.DataSource = dt;
                GridView1.DataBind();

                double v1 = Convert.ToDouble(GridView1.Rows[i].Cells[3].Text); //unit price
                int v2 = Convert.ToInt32(GridView1.Rows[i].Cells[4].Text);  //ordered quantity
                double cal = v1 * v2;
                GridView1.Rows[i].Cells[5].Text = Convert.ToString(cal);
                this.calculateGrandToral();
            }
            catch(Exception ex)
            {
                ex.ToString();
            }
        }


        private void BindGrid1()
        {
            DataTable dtt = (DataTable)ViewState["CurrentData"];    
            GridView1.DataSource = dtt;
            GridView1.DataBind();
           
        }
        private void calculateGrandToral()
        {
            decimal aaa, bbb = 0;
            for (int j = 0; j < (GridView1.Rows.Count); j++)
            {
                aaa = Convert.ToDecimal(GridView1.Rows[j].Cells[5].Text.ToString());
                bbb = bbb + aaa; //storing total qty into variable 
                GridView1.FooterRow.Cells[5].Text = bbb.ToString();
                GridView1.FooterRow.Cells[4].Text = "Grand Total = ";
            }
        }

       

        //protected void Button1_Click(object sender, EventArgs e)
        //{
           
        //    GridView1.AllowPaging = false;
        //    this.BindGrid1();
        //    this.calculateGrandToral();
        //    StringWriter sw = new StringWriter();
        //    HtmlTextWriter hw = new HtmlTextWriter(sw);
        //    GridView1.RenderControl(hw);
        //    string gridHTML = sw.ToString().Replace("\"", "'").Replace(System.Environment.NewLine, "");
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("<script type = 'text/javascript'>");
        //    sb.Append("window.onload = new function(){");
        //    sb.Append("var printWin = window.open('', '', 'left=0");
        //    sb.Append(",top=0,width=1000,height=600,status=0');");
        //    sb.Append("printWin.document.write(\"");
        //    sb.Append(gridHTML);
        //    sb.Append("\");");
        //    sb.Append("printWin.document.close();");
        //    sb.Append("printWin.focus();");
        //    sb.Append("printWin.print();");
        //    sb.Append("printWin.close();};");
        //    sb.Append("</script>");
        //    ClientScript.RegisterStartupScript(this.GetType(), "GridPrint", sb.ToString());
        //    GridView1.AllowPaging = true;
        //    this.BindGrid1();
        //}



        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    using (StringWriter sw = new StringWriter())
        //    {
        //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
        //        {
        //            //To Export all pages
        //            GridView1.AllowPaging = false;
        //            this.BindGrid1();
        //            this.calculateGrandToral();
        //            GridView1.RenderControl(hw);
        //            StringReader sr = new StringReader(sw.ToString());
        //            Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
        //            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //            pdfDoc.Open();
        //            htmlparser.Parse(sr);
        //            pdfDoc.Close();

        //            Response.ContentType = "application/pdf";
        //            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.pdf");
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.Write(pdfDoc);
        //            Response.End();
        //        }
        //    }

        //}

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnSaveGrid_Click(object sender, EventArgs e)
        {
            GridView1.AllowPaging = false;
            this.BindGrid1();
            saveGrid();
            this.updateStock();
            this.clearBill();
            //GridView1.AllowPaging = true;
            //this.BindGrid1();
            //this.calculateGrandToral();
          //  this.updateStock();
           
        }

        private void saveGrid()
        {
            foreach(GridViewRow gvrow in GridView1.Rows)
            {
                try
                {
                    SqlConnection scon = new SqlConnection(CS);
                    SqlCommand scmd = new SqlCommand(" INSERT INTO Invoice (ProductName,P_Qty,P_Price,P_OrderQty,P_Total,InvoiceNumber) VALUES('" + gvrow.Cells[1].Text + "','" + gvrow.Cells[2].Text + "','" + gvrow.Cells[3].Text + "','" + gvrow.Cells[4].Text + "','" + gvrow.Cells[5].Text + "','" + txtInvoice.Text.Trim() + "')", scon);
                    scon.Open();
                    scmd.ExecuteNonQuery();
                    scon.Close();
                }
                catch(Exception ex)
                {
                    ex.ToString();
                }
            }
          
            Label1.Visible = true;
            Label1.Text = "Record Saved";
        
        }
        private void updateStock()
        {
            try
            {
                SqlConnection con22 = new SqlConnection(CS);
                SqlCommand cmd33 = new SqlCommand();
                cmd33.Connection = con22;
                con22.Open();
                for (int p = 0; p < GridView1.Rows.Count; p++)
                {
                    string namee = GridView1.Rows[p].Cells[1].Text;  // product name
                    int xx = Convert.ToInt32(GridView1.Rows[p].Cells[2].Text); //stock
                    int yy = Convert.ToInt32(GridView1.Rows[p].Cells[4].Text); //ordered
                    int tempp = xx - yy;  //updated stock
                    string temp2 = Convert.ToString(tempp); //updated stock in string
                    cmd33.CommandText = "UPDATE Medicines SET [P_Qty]='" + temp2 + "' where ProductName='" + namee + "'";
                    //SqlDataReader rdr33 = cmd33.ExecuteReader();
                    cmd33.ExecuteNonQuery();
                }

                con22.Close();

            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            //Label4.Visible = true;
            //Label4.Text = "stock updated";
            //SqlConnection con = new SqlConnection(CS);
            //b = stock quantity
            //int updatedQty = b - orderQtyy;
            //string updatedQtyy = Convert.ToString(updatedQty);
            // SqlCommand cmd3 = new SqlCommand();
            //cmd3.Connection = con;
            //con.Open();
            //cmd3.CommandText = "UPDATE Medicines SET [P_Qty]='" + updatedQtyy + "' where ProductName='" + txtMedicineName.Text.Trim() + "'";

            //SqlDataReader rdr3 = cmd3.ExecuteReader();
            //con.Close();
        }



        //protected void Button1_Click1(object sender, EventArgs e)
        //{

        //    SqlConnection cons = new SqlConnection(CS);
        //    SqlCommand comn = new SqlCommand();
        //    comn.Connection = cons;
        //    cons.Open();
        //    // comn.CommandText = "Select ProductName from Medicines where P_Salt='" + txtSalt.Text.Trim() + "' ";
        //    comn.CommandText = "Select ProductName from medicines Where P_Salt LIKE '" + txtSalt.Text.Trim() + "'";
        //    SqlDataReader rdrs = comn.ExecuteReader();

        //    DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Alternate Medicine"));
        //    while (rdrs.Read())
        //    {
        //        //DropDownList1.Items.Add((rdrs.GetString(0).Trim()));


        //        DropDownList1.Items.Add(rdrs[0].ToString());

        //    }

        //    rdrs.Close();
        //    cons.Close();
        //    Button1.Visible = false;
        //}

        private void clearBill()
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            ViewState["CurrentData"] = null;
        //    ViewState.Remove("CurrentData");
            txtMedicineName.Text = "";
            txtOrderQty.Text = "";
            btnSaveGrid.Visible = false;
            this.InvoiceData();
        }

        private void alternateMedicine()
        {
           // Label3.Visible = false;
         //   lblDuplicate.Visible = false;
            //Label3.Text = "";
            DropDownList1.Visible = true;
            try
            {
                SqlConnection cons = new SqlConnection(CS);
                SqlCommand comn = new SqlCommand();
                comn.Connection = cons;
                cons.Open();
                // comn.CommandText = "Select ProductName from Medicines where P_Salt='" + txtSalt.Text.Trim() + "' ";
                //  comn.CommandText = "Select ProductName from medicines Where P_Salt LIKE '" + txtSalt.Text.Trim() + "'";
                comn.CommandText = "Select ProductName from medicines Where P_Salt LIKE '" + salt.ToString().Trim() + "'";
                SqlDataReader rdrs = comn.ExecuteReader();

                DropDownList1.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Select Alternate Medicine"));
                while (rdrs.Read())
                {
                    //DropDownList1.Items.Add((rdrs.GetString(0).Trim()));


                    DropDownList1.Items.Add(rdrs[0].ToString());

                }

                rdrs.Close();
                cons.Close();

            }
            catch(Exception ex)
            {
                ex.ToString();
            }
            // Button1.Visible = false;
        }

      

       

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedItem != null)
             txtMedicineName.Text = DropDownList1.SelectedItem.Text;
           
            lblDuplicate.Text = "";
            Label3.Text = "";
            txtOrderQty.Focus();

        }







        protected void lnkbtnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

       

        protected void lnkbtnSignout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            Response.Redirect("Index.aspx");
        }

        protected void lnkbtnChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changePassword.aspx");
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