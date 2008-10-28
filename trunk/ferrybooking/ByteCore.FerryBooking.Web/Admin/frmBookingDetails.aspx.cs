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
using System.Text;

namespace ByteCore.FerryBooking.Web
{
    public partial class frmBookingDetails : BasePage
    {
        private string _bookingId;
        private RouteOrderPassengerDetailList _pList;
        private RouteOrderVehicleDetailList _vList;
        private RouteOrderList _roList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {       
                if (string.IsNullOrEmpty(Request.QueryString["bId"]))
                    Response.Redirect("frmBooking.aspx");
                else
                    _bookingId = Request.QueryString["bId"];

                Label lblPageTitle = this.Master.Page.Form.FindControl("lblPageTitle") as Label;
                if (lblPageTitle != null)
                    lblPageTitle.Text = "Booking Details";

                BindStatus();
                BindBooking();
                BindList();
                //BindPassengers();
                BindRoutes();
            }
        }

        private void BindRoutes()
        {
            int bookingId = Convert.ToInt32(_bookingId);
            RouteOrder ro = new RouteOrder();
            _roList = ro.GetRouteOrderList(bookingId);
            this.Rpt_RouteList.DataSource = _roList;
            this.Rpt_RouteList.DataBind();
        }

        private void BindPassengers()
        {
            //int bookingId = Convert.ToInt32(_bookingId);
            //RouteOrderPassengerDetail p = new RouteOrderPassengerDetail();
            //_pList = p.GetPassengerList(bookingId);
            //this.Rpt_PassengerList.DataSource = _pList;
            //this.Rpt_PassengerList.DataBind();
        }

        private void BindBooking()
        {
            Booking b = new Booking().GetById(Convert.ToInt32(_bookingId), false);
            this.lblBookingId.Text = b.ID.ToString();
            this.lblBookingDate.Text = b.BookingDate.HasValue ? b.BookingDate.Value.ToShortDateString() : "";
            this.txtComments.Text = b.Comment.Trim();
            this.lblTotalAmount.Text = b.TotalAmount.ToString("C");
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

        protected void Rpt_PassengerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {            
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            RouteOrderPassengerDetail p = (RouteOrderPassengerDetail)e.Item.DataItem;   
            Label lblPassengerTitle = (Label)e.Item.FindControl("lblPassengerTitle");
            Panel pnlPassengerAdditionalInfo = (Panel)e.Item.FindControl("pnlPassengerAdditionalInfo");
            bool isLeader = p.IsLeader.GetValueOrDefault(false);
            if (isLeader)
            {
                lblPassengerTitle.Text = "Primary Passenger " + e.Item.ItemIndex.ToString() + " (" + p.RouteOrder.Schedule.Fare.Routes.DeparturePort.PortName + " - " +
                    p.RouteOrder.Schedule.Fare.Routes.ArriavlPort.PortName + ")";
                pnlPassengerAdditionalInfo.Visible = true;
            }
            else
            {
                lblPassengerTitle.Text = "Accompany Passenger " + e.Item.ItemIndex.ToString() + " (" + p.RouteOrder.Schedule.Fare.Routes.DeparturePort.PortName + " - " +
                    p.RouteOrder.Schedule.Fare.Routes.ArriavlPort.PortName + ")";
                pnlPassengerAdditionalInfo.Visible = false;
            }
        }
        protected void Rpt_VehicleList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            RouteOrderVehicleDetail v = (RouteOrderVehicleDetail)e.Item.DataItem;
            Label lblVehicleTitle = (Label)e.Item.FindControl("lblVehicleTitle");
            lblVehicleTitle.Text = "Vehicle " + e.Item.ItemIndex.ToString();

        }
        protected void Rpt_RouteList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            RouteOrder ro = (RouteOrder)e.Item.DataItem;
            Label lblRouteTitle = (Label)e.Item.FindControl("lblRouteTitle");
            lblRouteTitle.Text = " Route " + e.Item.ItemIndex.ToString() + " (" + ro.Schedule.Fare.Routes.DeparturePort.PortName + " - " +
                    ro.Schedule.Fare.Routes.ArriavlPort.PortName + ")";

            Label lblRouteTotalAmount = (Label)e.Item.FindControl("lblRouteTotalAmount");
            lblRouteTotalAmount.Text = ro.RouteTotalAmount.ToString("C");
            //Bind Passengers;
            Repeater rptPassengers = (Repeater)e.Item.FindControl("Rpt_PassengerList");
            RouteOrderPassengerDetail p = new RouteOrderPassengerDetail();
            _pList = p.GetPassengerListByRoute(ro.ID);
            rptPassengers.DataSource = _pList;
            rptPassengers.DataBind();
            //Bind Vehicles
            Repeater rptVehicleList = (Repeater)e.Item.FindControl("Rpt_VehicleList");
            RouteOrderVehicleDetail v = new RouteOrderVehicleDetail();
            _vList = v.GetVehicleListByRoute(ro.ID);
            rptVehicleList.DataSource = _vList;
            rptVehicleList.DataBind();
            Label lblCabinInfo = (Label)e.Item.FindControl("lblCabinInfo");
            RouteOrderDetailList cabinList = ro.GetListByRoute(1);
            StringBuilder sb = new StringBuilder();
            foreach (RouteOrderDetail item in cabinList)
            {
                sb.Append(item.FareType.FullFareTypeName);
                sb.Append("<br />");
            }
            lblCabinInfo.Text = sb.ToString();
            Label lblAddonInfo = (Label)e.Item.FindControl("lblAddonInfo");
            RouteOrderDetailList addonList = ro.GetListByRoute(4);
            StringBuilder sb1 = new StringBuilder();
            foreach (RouteOrderDetail item in addonList)
            {
                sb1.Append(item.FareType.FullFareTypeName);
                sb1.Append("<br />");
            }
            lblAddonInfo.Text = sb1.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int bookingId = Convert.ToInt32(this.lblBookingId.Text.Trim());
            Booking b = new Booking().GetById(bookingId, true);
            b.Comment = this.txtComments.Text.Trim();
            if (this.ddlStatus.SelectedIndex != -1)
                b.Status = Convert.ToInt32(this.ddlStatus.SelectedValue);
            b.Update();
            this.lblMessage.Text = "Update successfully";
        }
    }
}
