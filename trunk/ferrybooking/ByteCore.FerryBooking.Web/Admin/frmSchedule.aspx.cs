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
    public partial class frmSchedule : BasePage
    {
        private Schedule _schedule;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
                BindList();
                this.FV_Schedule.Visible = false;
            }
        }

        private void BindControls()
        {
            Vessel v = new Vessel();
            VesselList vlist = v.GetAllList();
            this.ddlVessel.DataSource = vlist;
            this.ddlVessel.DataTextField = "FullName";
            this.ddlVessel.DataValueField = "ID";
            this.ddlVessel.DataBind();
            this.ddlVessel.Items.Insert(0, new ListItem("-- Show All --", "0"));

            Fare f = new Fare();
            FareList flist = f.GetAllList();
            this.ddlFare.DataSource = flist;
            this.ddlFare.DataTextField = "FullName";
            this.ddlFare.DataValueField = "ID";
            this.ddlFare.DataBind();
            this.ddlFare.Items.Insert(0, new ListItem("-- Show All --", "0"));
        }

        private void BindList()
        {
            Schedule schedule = new Schedule();
            int vesselId = 0;
            int fareId = 0; ;
            if (this.ddlVessel.SelectedIndex != -1)
                int.TryParse(this.ddlVessel.SelectedValue, out vesselId);
            if (this.ddlFare.SelectedIndex != -1)
                int.TryParse(this.ddlFare.SelectedValue, out fareId);
            DateTime startTime = new DateTime(1900, 1, 1);
            DateTime endTime = DateTime.MaxValue;
            DateTime.TryParse(this.txtStartDate.Text, out startTime);
            DateTime.TryParse(this.txtEndDate.Text, out endTime);
            if (startTime == DateTime.MinValue)
                startTime = new DateTime(1900, 1, 1);
            if (endTime == DateTime.MinValue)
                endTime = DateTime.MaxValue;
            if (endTime != DateTime.MaxValue)
                endTime = endTime.AddDays(1.0);
            ScheduleList list = schedule.GetScheduleList(vesselId, fareId, startTime, endTime);
            this.GV_ScheduleList.DataSource = list;
            this.GV_ScheduleList.DataBind();
            this.lblMessage.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.FV_Schedule.ChangeMode(FormViewMode.Insert);
            this.FV_Schedule.Visible = true;
            BindList();
        }

        protected void GV_ScheduleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_ScheduleEdit.SelectParameters["id"].DefaultValue = this.GV_ScheduleList.SelectedValue.ToString();
            this.FV_Schedule.DataBind();
            this.FV_Schedule.ChangeMode(FormViewMode.Edit);
            this.FV_Schedule.Visible = true;
            BindList();
        }

        protected void GV_ScheduleList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.FV_Schedule.Visible = false;
            this.lblMessage.Text = "Delete successfully";
            this.lblMessage.ForeColor = Color.Green;
            BindList();
        }

        protected void GV_ScheduleList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GV_ScheduleList.PageIndex = e.NewPageIndex;
            BindList();
        }

        protected void FV_Schedule_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertSchedule();
                    break;
                case "DoUpdate":
                    UpdateSchedule(Convert.ToInt32(e.CommandArgument));
                    break;
                case "DoCancel":
                    this.FV_Schedule.Visible = false;
                    BindList();
                    break;
            }
        }

        private void UpdateSchedule(int id)
        {
            int vesselId;
            int fareId;
            DateTime sailingTime;
            DateTime arrivalTime;

            DropDownList ddlVessel = (DropDownList)this.FV_Schedule.FindControl("ddlVessel");
            DropDownList ddlFare = (DropDownList)this.FV_Schedule.FindControl("ddlFare");
            TextBox txtSailingTime = (TextBox)this.FV_Schedule.FindControl("txtSailingTime");
            TextBox txtArrivalTime = (TextBox)this.FV_Schedule.FindControl("txtArrivalTime");

            vesselId = (ddlVessel == null) ? 0 : Convert.ToInt32(ddlVessel.SelectedValue);
            fareId = (ddlFare == null) ? 0 : Convert.ToInt32(ddlFare.SelectedValue);

            if (DateTime.TryParse(txtSailingTime.Text.Trim(), out sailingTime)
                && DateTime.TryParse(txtArrivalTime.Text.Trim(), out arrivalTime)
                && vesselId != 0 && fareId != 0)
            {
                Schedule schedule = new Schedule();
                schedule.DoUpdate(id, vesselId, fareId, sailingTime, arrivalTime);
                BindList();

                if (ddlVessel != null)
                    ddlVessel.SelectedIndex = 0;
                if (ddlFare != null)
                    ddlFare.SelectedIndex = 0;

                this.lblMessage.Text = "Update successfully";
                this.lblMessage.ForeColor = Color.Green;
            }
            else
            {
                this.lblMessage.Text = "Update failed";
                this.lblMessage.ForeColor = Color.Red;
            }
        }

        private void InsertSchedule()
        {
            int vesselId;
            int fareId;
            DateTime sailingTime;
            DateTime arrivalTime;

            DropDownList ddlVessel = (DropDownList)this.FV_Schedule.FindControl("ddlVessel");
            DropDownList ddlFare = (DropDownList)this.FV_Schedule.FindControl("ddlFare");
            TextBox txtSailingTime = (TextBox)this.FV_Schedule.FindControl("txtSailingTime");
            TextBox txtArrivalTime = (TextBox)this.FV_Schedule.FindControl("txtArrivalTime");

            vesselId = (ddlVessel == null) ? 0 : Convert.ToInt32(ddlVessel.SelectedValue);
            fareId = (ddlFare == null) ? 0 : Convert.ToInt32(ddlFare.SelectedValue);

            if (DateTime.TryParse(txtSailingTime.Text.Trim(), out sailingTime)
                && DateTime.TryParse(txtArrivalTime.Text.Trim(), out arrivalTime)
                && vesselId != 0 && fareId != 0)
            {
                _schedule = new Schedule();
                _schedule.VesselId = vesselId;
                _schedule.FareId = fareId;
                _schedule.SailingTime = sailingTime;
                _schedule.ArrivalTime = arrivalTime;
                Schedule.DoInsert(_schedule);

                BindList();

                if (ddlVessel != null)
                    ddlVessel.SelectedIndex = 0;
                if (ddlFare != null)
                    ddlFare.SelectedIndex = 0;

                this.lblMessage.Text = "Insert successfully";
                this.lblMessage.ForeColor = Color.Green;
            }
            else
            {
                this.lblMessage.Text = "Insert failed";
                this.lblMessage.ForeColor = Color.Red;
            }
        }
    }
}
