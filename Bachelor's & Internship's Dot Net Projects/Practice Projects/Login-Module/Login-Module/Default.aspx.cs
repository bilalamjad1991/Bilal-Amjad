using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Login_Module
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["test"] = TextBox1.Text;
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SearchConsole.aspx");
        }
    }
}
