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
using System.Collections.Generic;

namespace ByteCore.FerryBooking.Web
{
    public partial class frmVessel : BasePage
    {
        private Vessel _vessel;
        private IList<FareType> _fareTypeList;
      
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                Label lblPageTitle = this.Master.Page.Form.FindControl("lblPageTitle") as Label;
                if (lblPageTitle != null)
                    lblPageTitle.Text = "Vessel";

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
            _fareTypeList = new List<FareType>();
            BindList();
            BindVesselCabinet(0);
        }

        protected void GV_VesselList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_VesselEdit.SelectParameters["id"].DefaultValue = this.GV_VesselList.SelectedValue.ToString();
            this.FV_Vessel.DataBind();
            this.FV_Vessel.ChangeMode(FormViewMode.Edit);
            this.FV_Vessel.Visible = true;
            BindList();
            BindVesselCabinet(Convert.ToInt32(this.GV_VesselList.SelectedValue));
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

        private void InsertVessel()
        {
            string vesselCode;
            string vesselName;
            int operatorId;

            TextBox txtVesselCode = (TextBox)this.FV_Vessel.FindControl("txtVesselCode");
            TextBox txtVesselName = (TextBox)this.FV_Vessel.FindControl("txtVesselName");
            DropDownList ddlOperator = (DropDownList)this.FV_Vessel.FindControl("ddlOperator");
            CheckBoxList chklstAccommodation = (CheckBoxList)this.FV_Vessel.FindControl("chklstAccommodation");
            
            vesselCode = (txtVesselCode == null) ? "" : (string.IsNullOrEmpty(txtVesselCode.Text) ? "" : txtVesselCode.Text);
            vesselName = (txtVesselName == null) ? "" : (string.IsNullOrEmpty(txtVesselName.Text) ? "" : txtVesselName.Text);
            operatorId = (ddlOperator == null) ? 0 : Convert.ToInt32(ddlOperator.SelectedValue);

            _vessel = new Vessel();
            _vessel.VesselCode = vesselCode;
            _vessel.VesselName = vesselName;
            _vessel.OperatorId = operatorId;

            for (int i = 0; i < chklstAccommodation.Items.Count; i++)
            {
                if (chklstAccommodation.Items[i].Selected)
                {
                    int ftId = Convert.ToInt32(chklstAccommodation.Items[i].Value);
                    FareType ft = new FareType().GetById(ftId, false);
                    _vessel.FareTypes.Add(ft);
                }
            }           

            Vessel.DoInsert(_vessel);

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

        private void UpdateVessel(int id)
        {
            string vesselCode;
            string vesselName;
            int operatorId;

            TextBox txtVesselCode = (TextBox)this.FV_Vessel.FindControl("txtVesselCode");
            TextBox txtVesselName = (TextBox)this.FV_Vessel.FindControl("txtVesselName");
            DropDownList ddlOperator = (DropDownList)this.FV_Vessel.FindControl("ddlOperator");
            CheckBoxList chklstAccommodation = (CheckBoxList)this.FV_Vessel.FindControl("chklstAccommodation");
            
            vesselCode = (txtVesselCode == null) ? "" : (string.IsNullOrEmpty(txtVesselCode.Text) ? "" : txtVesselCode.Text);
            vesselName = (txtVesselName == null) ? "" : (string.IsNullOrEmpty(txtVesselName.Text) ? "" : txtVesselName.Text);
            operatorId = (ddlOperator == null) ? 0 : Convert.ToInt32(ddlOperator.SelectedValue);
            
            Vessel vessel = new Vessel();
            IList<FareType> ftList = new List<FareType>();
            
            for (int i = 0; i < chklstAccommodation.Items.Count; i++)
            {
                if (chklstAccommodation.Items[i].Selected)
                {
                    int ftId = Convert.ToInt32(chklstAccommodation.Items[i].Value);
                    FareType ft = new FareType().GetById(ftId, false);
                    ftList.Add(ft);
                }
            }
            vessel.DoUpdate(id, vesselCode, vesselName, operatorId, ftList);
            BindList();

            this.lblMessage.Text = "Update successfully";
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
            BindVesselCabinet(Convert.ToInt32(this.GV_VesselList.SelectedValue));
        }

        private void BindVesselCabinet(int vesselId)
        {
            int operatorId;
            CheckBoxList chklstAccommodation = (CheckBoxList)this.FV_Vessel.FindControl("chklstAccommodation");
            DropDownList ddlOperator = (DropDownList)this.FV_Vessel.FindControl("ddlOperator");
            if (ddlOperator == null)
                return;

            operatorId = Convert.ToInt32(ddlOperator.SelectedValue);
            FareType fareType = new FareType();
            FareTypeList list = fareType.GetFareTypeList(operatorId, 1);
            chklstAccommodation.DataSource = list;
            chklstAccommodation.DataTextField = "FullName";
            chklstAccommodation.DataValueField = "ID";
            chklstAccommodation.DataBind();
            if (vesselId != 0)
            {
                Vessel v = new Vessel().GetById(vesselId, false);
                foreach (FareType ft in v.FareTypes)
                {
                    for (int i = 0; i < chklstAccommodation.Items.Count; i++)
                    {
                        if (chklstAccommodation.Items[i].Value == ft.ID.ToString())
                        {
                            chklstAccommodation.Items[i].Selected = true;
                            break;
                        }
                    }
                }
            }
        }
    }
}
