using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using Entities;

namespace MergeBatchEntityFW
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            BLCandidate obj = new BLCandidate();
            List<Candidates> allCandidates = new List<Candidates>();
            allCandidates = obj.ListCandidates();
            GridView1.DataSource = allCandidates;
            GridView1.DataBind();

        }
    }
}
