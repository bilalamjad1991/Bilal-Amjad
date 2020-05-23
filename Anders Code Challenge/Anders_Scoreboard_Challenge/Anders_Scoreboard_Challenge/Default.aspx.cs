using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Anders_Scoreboard_Challenge
{
    public partial class _Default : Page
    {
        //Declaring datatable for making scoreboard and binding it to gridview afterwards
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            
            if (!Page.IsPostBack)
            {
                //using viewstate for keeping records of name and score 
                if(ViewState["Records"]==null)
                
                {
                    //adding columns to datable
                    dt.Columns.Add("Name");
                    dt.Columns.Add("Score");
                    ViewState["Records"] = dt;
                    
                }

                bindgridview();
                
            }

            

        }

        private void bindgridview()
        {
            
            //adding datatable as a datasource to the gridview
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        

            //button for adding new scores to the scoreboard
        protected void Button1_Click(object sender, EventArgs e)
        {
            dt = (DataTable)ViewState["Records"];
            //adding rows to datatable and binding it to gridview afterwards
            dt.Rows.Add(txtName.Text,txtScore.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            //calculating highscore and displaying in the highscore textbox
            decimal min = 0, max = 0;

            string high;
            for (int j = 0; j < (GridView1.Rows.Count); j++)
            {
                max = Convert.ToDecimal(GridView1.Rows[j].Cells[1].Text.ToString());

                if (max > min)
                {
                    high = max.ToString();
                    txtHighScore.Text = high;
                    min = max;
                }
                else
                {
                    high = min.ToString();
                    txtHighScore.Text = high;
                }
            }

            
        }
        //method for sorting gridview in ascending and descending order
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sortExp = e.SortExpression;
            string direction = string.Empty;

            if (SortDir == SortDirection.Ascending)
            {
                SortDir = SortDirection.Descending;
                direction = "DESC";
            }
            else {
                SortDir = SortDirection.Ascending;
                direction = "ASC";
            }

            dt.DefaultView.Sort = sortExp + " " + direction;
           
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        public SortDirection SortDir             
        {
            get {
                if (ViewState["SortDir"] == null)
                {
                    ViewState["SortDir"] = SortDirection.Ascending;
                }
                return (SortDirection)ViewState["SortDir"];
            }
            set {
                ViewState["SortDir"] = value;
            }
        }

        

        

        
    }
}