using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using Telerik.Web.UI;


namespace Telerik.GridExamplesCSharp.DataEditing.AllEditableColumns
{
    public partial class DefaultCS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RadGrid1_ItemUpdated(object source, Telerik.Web.UI.GridUpdatedEventArgs e)
        {
            GridEditableItem item = (GridEditableItem)e.Item;
            String id = item.GetDataKeyValue("ProductID").ToString();

            if (e.Exception != null)
            {
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
                SetMessage("Product with ID " + id + " cannot be updated. Reason: " + e.Exception.Message);
            }
            else
            {
                SetMessage("Product with ID " + id + " is updated!");
            }
        }

        protected void RadGrid1_ItemInserted(object source, GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {

                e.ExceptionHandled = true;
                SetMessage("Product cannot be inserted. Reason: " + e.Exception.Message);

            }
            else
            {
                SetMessage("New product is inserted!");
            }
        }

        protected void RadGrid1_ItemDeleted(object source, GridDeletedEventArgs e)
        {
            GridDataItem dataItem = (GridDataItem)e.Item;
            String id = dataItem.GetDataKeyValue("ProductID").ToString();

            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                SetMessage("Product with ID " + id + " cannot be deleted. Reason: " + e.Exception.Message);
            }
            else
            {
                SetMessage("Product with ID " + id + " is deleted!");
            }
        }

        protected void RadioCheckedChanged(object sender, System.EventArgs e)
        {
            switch ((sender as RadioButton).ID)
            {
                case "RadioButton1":
                    {
                        RadGrid1.MasterTableView.EditMode = GridEditMode.EditForms;
                        RadioButton2.Checked = false;
                        break;
                    }
                case "RadioButton2":
                    {
                        RadGrid1.MasterTableView.EditMode = GridEditMode.InPlace;
                        RadioButton1.Checked = false;
                        break;
                    }
            }
            RadGrid1.Rebind();
        }
        protected void CheckboxCheckedChanged(object sender, System.EventArgs e)
        {

            RadGrid1.AllowMultiRowEdit = CheckBox1.Checked;

            RadGrid1.Rebind();
        }

        private void DisplayMessage(string text)
        {
            RadGrid1.Controls.Add(new LiteralControl(string.Format("<span style='color:red'>{0}</span>", text)));
        }

        private void SetMessage(string message)
        {
            gridMessage = message;
        }

        private string gridMessage = null;

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridMessage))
            {
                DisplayMessage(gridMessage);
            }
        }
    }
}