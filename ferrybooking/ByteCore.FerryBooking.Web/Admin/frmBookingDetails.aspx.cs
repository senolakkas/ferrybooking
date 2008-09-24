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
    public partial class frmBookingDetails : BasePage
    {
        private string _bookingId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["bId"]))
                    Response.Redirect("frmBooking.aspx");
                else
                    _bookingId = Request.QueryString["bId"];
                BindStatus();
                BindBooking();
                BindList();
                BindPassengers();
                BindRoutes();
            }
        }

        private void BindRoutes()
        {
            return;
        }

        private void BindPassengers()
        {
            return;
        }

        private void BindBooking()
        {
            Booking b = new Booking().GetById(Convert.ToInt32(_bookingId), false);
            this.lblBookingId.Text = b.ID.ToString();
            this.lblBookingDate.Text = b.BookingDate.HasValue ? b.BookingDate.Value.ToShortDateString() : "";
            this.txtComments.Text = b.Comment.Trim();
            //this.ddlStatus.sle            
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
            this.ddlStatus.Items.Insert(0, new ListItem("-- None --", "0"));
            this.ddlStatus.SelectedIndex = 0;
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
            //Booking b = new Booking().GetById();
            //int statusId = 0;
            //if (this.ddlStatus.SelectedIndex != -1)
            //    int.TryParse(this.ddlStatus.SelectedValue, out statusId);
            //DateTime startDate = new DateTime(1900, 1, 1);
            //DateTime endDate = DateTime.MaxValue;
            //DateTime.TryParse(this.txtStartDate.Text, out startDate);
            //DateTime.TryParse(this.txtEndDate.Text, out endDate);
            //if (startDate == DateTime.MinValue)
            //    startDate = new DateTime(1900, 1, 1);
            //if (endDate == DateTime.MinValue)
            //    endDate = DateTime.MaxValue;
            //BookingList list = b.GetBookingList(statusId, startDate, endDate);
            //this.GV_BookingList.DataSource = list;
            //this.GV_BookingList.DataBind();
            //this.lblMessage.Text = "";
        }
    }
}
