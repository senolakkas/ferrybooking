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

namespace ByteCore.FerryBooking.Web.Admin
{
    public partial class frmVessel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                this.FV_Vessel.Visible = false;
            }
        }

        private void BindList()
        {
            this.ODS_VesselList.SelectParameters["vesselCode"].DefaultValue = this.txtVesselCode.Text.Trim();
            this.GV_VesselList.DataBind();
            this.lblMessage.Text = "";
        }

        private void BindOperator()
        {
            Company c = new Company();
            CompanyList list = c.GetAllList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.FV_Vessel.ChangeMode(FormViewMode.Insert);
            this.FV_Vessel.Visible = true;
            BindList();
            BindVesselCabinet();
        }

        protected void GV_VesselList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_VesselEdit.SelectParameters["id"].DefaultValue = this.GV_VesselList.SelectedValue.ToString();
            this.FV_Vessel.DataBind();
            this.FV_Vessel.ChangeMode(FormViewMode.Edit);
            this.FV_Vessel.Visible = true;
            BindList();
            BindVesselCabinet();
        }

        protected void FV_Vessel_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertVessel();
                    break;
                case "DoUpdate":
                    UpdateVessel(Convert.ToInt32(e.CommandArgument));
                    break;
                case "DoCancel":
                    //this.FV_Vessel.ChangeMode(FormViewMode.ReadOnly);
                    this.FV_Vessel.Visible = false;
                    BindList();
                    break;
            }
        }

        private void UpdateVessel(int id)
        {
            string vesselCode;
            string vesselName;
            int operatorId;

            TextBox txtVesselCode = (TextBox)this.FV_Vessel.FindControl("txtVesselCode");
            TextBox txtVesselName = (TextBox)this.FV_Vessel.FindControl("txtVesselName");
            DropDownList ddlOperator = (DropDownList)this.FV_Vessel.FindControl("ddlOperator");

            vesselCode = (txtVesselCode == null) ? "" : (string.IsNullOrEmpty(txtVesselCode.Text) ? "" : txtVesselCode.Text);
            vesselName = (txtVesselName == null) ? "" : (string.IsNullOrEmpty(txtVesselName.Text) ? "" : txtVesselName.Text);
            operatorId = (ddlOperator == null) ? 0 : Convert.ToInt32(ddlOperator.SelectedValue);

            Vessel vessel = new Vessel();
            vessel.DoUpdate(id, vesselCode, vesselName, operatorId);
            BindList();

            if (txtVesselCode != null)
                txtVesselCode.Text = string.Empty;
            if (txtVesselName != null)
                txtVesselName.Text = string.Empty;
            if (ddlOperator != null)
                ddlOperator.SelectedIndex = 0;

            this.lblMessage.Text = "Update successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        private void InsertVessel()
        {
            string vesselCode;
            string vesselName;
            int operatorId;

            TextBox txtVesselCode = (TextBox)this.FV_Vessel.FindControl("txtVesselCode");
            TextBox txtVesselName = (TextBox)this.FV_Vessel.FindControl("txtVesselName");
            DropDownList ddlOperator = (DropDownList)this.FV_Vessel.FindControl("ddlOperator");

            vesselCode = (txtVesselCode == null) ? "" : (string.IsNullOrEmpty(txtVesselCode.Text) ? "" : txtVesselCode.Text);
            vesselName = (txtVesselName == null) ? "" : (string.IsNullOrEmpty(txtVesselName.Text) ? "" : txtVesselName.Text);
            operatorId = (ddlOperator == null) ? 0 : Convert.ToInt32(ddlOperator.SelectedValue);

            Vessel vessel = new Vessel();
            vessel.DoInsert(vesselCode, vesselName, operatorId);
            BindList();

            if (txtVesselCode != null)
                txtVesselCode.Text = string.Empty;
            if (txtVesselName != null)
                txtVesselName.Text = string.Empty;
            if (ddlOperator != null)
                ddlOperator.SelectedIndex = 0;

            this.lblMessage.Text = "Insert successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        protected void GV_VesselList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //this.FV_Vessel.ChangeMode(FormViewMode.ReadOnly);
            this.FV_Vessel.Visible = false;
            this.lblMessage.Text = "Delete successfully";
            this.lblMessage.ForeColor = Color.Green;
            BindList();
        }

        protected void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindVesselCabinet();
        }

        private void BindVesselCabinet()
        {
            int operatorId;
            Panel pnlCabinet = (Panel)this.FV_Vessel.FindControl("pnlCabinet");
            DropDownList ddlOperator = (DropDownList)this.FV_Vessel.FindControl("ddlOperator");
            if (pnlCabinet == null || ddlOperator == null)
                return;

            operatorId = Convert.ToInt32(ddlOperator.SelectedValue);
            FareType fareType = new FareType();
            FareTypeList list = fareType.GetFareTypeList(operatorId, 1);

            foreach (FareType ft in list)
            {
                CheckBox cb = new CheckBox();
                cb.ID = "chk_Cabinet_" + ft.ID;
                cb.Text = ft.FullFareTypeName;
                pnlCabinet.Controls.Add(cb);
                pnlCabinet.Controls.Add(new LiteralControl("<br />"));
            }
        }
    }
}
