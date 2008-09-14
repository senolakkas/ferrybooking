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
    public partial class frmBooking : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStatus();
                BindList();
            }
        }

        private void BindStatus()
        {
            string[] status = Enum.GetNames(typeof(BookingStatus));
            Array values = Enum.GetValues(typeof(BookingStatus));
            for (int i = 0; i <= status.Length - 1; i++)
            {
                this.ddlStatus.Items.Add(new ListItem(status[i], Convert.ToInt32(values.GetValue(i)).ToString()));
            }

            //Hashtable ht = GetEnumForBind(typeof(BookingStatus));
            //this.ddlStatus.DataSource = ht;
            //this.ddlStatus.DataTextField = "value";
            //this.ddlStatus.DataValueField = "key";
            //this.ddlStatus.DataBind();

            this.ddlStatus.SelectedIndex = -1;
        }

        //Another way to bind enum to dropdownlist
        public Hashtable GetEnumForBind(Type enumeration)
        {
            string[] names = Enum.GetNames(enumeration);
            Array values = Enum.GetValues(enumeration);
            Hashtable ht = new Hashtable();
            for (int i = 0; i < names.Length; i++)
            {
                ht.Add(Convert.ToInt32(values.GetValue(i)).ToString(), names[i]);
            }
            return ht;
        }

        private void BindList()
        {
            Booking b = new Booking();
            int status = -1;
            if (this.ddlStatus.SelectedIndex != -1)
                status = int.Parse(this.ddlStatus.SelectedValue);
            DateTime startDate = new DateTime(1900, 1, 1);
            DateTime endDate = DateTime.MaxValue;
            DateTime.TryParse(this.txtStartDate.Text, out startDate);
            DateTime.TryParse(this.txtEndDate.Text, out endDate);
            if (startDate == DateTime.MinValue)
                startDate = new DateTime(1900, 1, 1);
            if (endDate == DateTime.MinValue)
                endDate = DateTime.MaxValue;
            BookingList list = b.GetBookingList(status, startDate, endDate);
            this.GV_BookingList.DataSource = list;
            this.GV_BookingList.DataBind();
            this.lblMessage.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void GV_BookingList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindList();
        }

        protected void GV_BookingList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GV_BookingList.PageIndex = e.NewPageIndex;
            BindList();
        }
    }
}
