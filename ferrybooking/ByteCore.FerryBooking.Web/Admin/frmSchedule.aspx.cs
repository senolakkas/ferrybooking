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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControls();
                BindList();
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
            BindList();
        }

        protected void GV_ScheduleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindList();

        }

        protected void GV_ScheduleList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            BindList();
        }

        protected void ddlVessel_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void GV_ScheduleList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GV_ScheduleList.PageIndex = e.NewPageIndex;
            BindList();
        }
    }
}
