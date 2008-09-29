using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ByteCore.FerryBooking.Core;
using System.Drawing;

namespace ByteCore.FerryBooking.Web
{
    public partial class frmPort : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                Label lblPageTitle = this.Master.Page.Form.FindControl("lblPageTitle") as Label;
                if (lblPageTitle != null)
                    lblPageTitle.Text = "Port";

                this.FV_Port.Visible = false;
            }
        }

        private void BindList()
        {
            this.ODS_PortList.SelectParameters["portName"].DefaultValue = this.txtPortName.Text.Trim();
            this.GV_PortList.DataBind();
            this.lblMessage.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.FV_Port.ChangeMode(FormViewMode.Insert);
            this.FV_Port.Visible = true;
            BindList();
        }
        protected void GV_PortList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_PortEdit.SelectParameters["id"].DefaultValue = this.GV_PortList.SelectedValue.ToString();
            this.FV_Port.DataBind();
            this.FV_Port.ChangeMode(FormViewMode.Edit);
            this.FV_Port.Visible = true;
            BindList();
        }

        protected void FV_Port_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertPort();
                    break;
                case "DoUpdate":
                    UpdatePort(e.CommandArgument.ToString());
                    break;
                case "DoCancel":
                    //this.FV_Port.ChangeMode(FormViewMode.ReadOnly);
                    this.FV_Port.Visible = false;
                    BindList();
                    break;
            }
        }

        private void UpdatePort(string id)
        {
            string portName;
            TextBox txtPortName = (TextBox)this.FV_Port.FindControl("txtPortName");
            portName = (txtPortName == null) ? "" : (string.IsNullOrEmpty(txtPortName.Text) ? "" : txtPortName.Text);

            Port port = new Port();
            port.DoUpdate(id, portName);
            BindList();

            this.lblMessage.Text = "Update successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        private void InsertPort()
        {
            string portCode;
            string portName;

            TextBox txtPortCode = (TextBox)this.FV_Port.FindControl("txtPortCode");
            TextBox txtPortName = (TextBox)this.FV_Port.FindControl("txtPortName");

            portCode = (txtPortCode == null) ? "" : (string.IsNullOrEmpty(txtPortCode.Text) ? "" : txtPortCode.Text.Trim());
            portName = (txtPortName == null) ? "" : (string.IsNullOrEmpty(txtPortName.Text) ? "" : txtPortName.Text.Trim());

            Port existingPort = new Port().GetById(portCode, false);
            if (existingPort == null)
            {
                Port port = new Port();
                port.DoInsert(portCode, portName);
                BindList();

                this.lblMessage.Text = "Insert successfully";
                this.lblMessage.ForeColor = Color.Green;
            }
            else
            {
                this.lblMessage.Text = "Deplicate Port Code found, please try another one.";
                this.lblMessage.ForeColor = Color.Red;
            }

            if (txtPortCode != null)
                txtPortCode.Text = string.Empty;
            if (txtPortName != null)
                txtPortName.Text = string.Empty;
        }

        protected void GV_PortList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //this.FV_Port.ChangeMode(FormViewMode.ReadOnly);
            this.FV_Port.Visible = false;
            this.lblMessage.Text = "Delete successfully";
            this.lblMessage.ForeColor = Color.Green;
            BindList();
        }

    }
}
