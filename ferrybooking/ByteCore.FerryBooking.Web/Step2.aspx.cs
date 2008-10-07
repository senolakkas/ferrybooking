using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ByteCore.FerryBooking.Core;
using System.Collections.Generic;

namespace ByteCore.FerryBooking.Web
{
    public partial class Step2 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session[ByteCore.FerryBooking.Web.SessionVariable.Step1UserInput] is Step1UserInput))
            {
                Response.Redirect("Default.aspx");
            }
            Step1UserInput step1 = (Step1UserInput)Session[SessionVariable.Step1UserInput];
            if (!Page.IsPostBack)
            {
                RouteList routelist = new RouteList();
                Route r1 = new Route().GetById(step1.Route1Id,false);
                routelist.Add(r1);

                Hashtable htSchedulePreLoad = new Hashtable();
                htSchedulePreLoad.Add(r1.ID.ToString(),InitRouteSchedule(step1.Route1Id));

                if (step1.Route2Id>0)
                {
                    Route r2 = new Route().GetById(step1.Route2Id, false);
                    routelist.Add(r2);
                    htSchedulePreLoad.Add(r2.ID.ToString(), InitRouteSchedule(step1.Route2Id));
                }

                if (step1.Route3Id>0)
                {
                    Route r3 = new Route().GetById(step1.Route3Id, false);
                    routelist.Add(r3);
                    htSchedulePreLoad.Add(r3.ID.ToString(), InitRouteSchedule(step1.Route3Id));
                }

                if (step1.Route4Id > 0)
                {
                    Route r4 = new Route().GetById(step1.Route4Id, false);
                    routelist.Add(r4);
                    htSchedulePreLoad.Add(r4.ID.ToString(), InitRouteSchedule(step1.Route4Id));
                }

                Session[SessionVariable.RouteSchedules] = htSchedulePreLoad;

                this.lvSchedule.DataSource = routelist;
                lvSchedule.DataBind();
                RouteOrderPassengerDetailList passengerList = new RouteOrderPassengerDetailList();
                for (int i = 0; i < step1.PassengersCount; i++)
                {
                    passengerList.Add(new RouteOrderPassengerDetail());
                }

                lvPassenger.DataSource = passengerList;
                lvPassenger.DataBind();
            }
        }

        private Dictionary<string, object> InitRouteSchedule(int routeId)
        {
            DateTime dtNow = new DateTime(2008, 6, 1);
            ScheduleList routeScheduleList;
            routeScheduleList = new Schedule().GetScheduleListForRoute(routeId, dtNow);
            Dictionary<string,object> routeSchedules = new Dictionary<string,object>();
            foreach (Schedule s in routeScheduleList)
            {
                if (!routeSchedules.ContainsKey(s.SailingTime.Value.Year.ToString()))
                    routeSchedules.Add(s.SailingTime.Value.Year.ToString(), null);
                if (routeSchedules[s.SailingTime.Value.Year.ToString()] == null)
                    routeSchedules[s.SailingTime.Value.Year.ToString()] = new Dictionary<string, object>();

                Dictionary<string, object> monthList = (Dictionary<string, object>)routeSchedules[s.SailingTime.Value.Year.ToString()];
                if (!monthList.ContainsKey(s.SailingTime.Value.ToString("MMMM")))
                    monthList.Add(s.SailingTime.Value.ToString("MMMM"), null);
                if (monthList[s.SailingTime.Value.ToString("MMMM")] == null)
                    monthList[s.SailingTime.Value.ToString("MMMM")] = new Dictionary<string, object>();

                Dictionary<string, object> dayList = (Dictionary<string, object>)monthList[s.SailingTime.Value.ToString("MMMM")];
                if (!dayList.ContainsKey(s.SailingTime.Value.ToString("ddd dd")))
                    dayList.Add(s.SailingTime.Value.ToString("ddd dd"), null);
                if (dayList[s.SailingTime.Value.ToString("ddd dd")] == null)
                    dayList[s.SailingTime.Value.ToString("ddd dd")] = new Dictionary<string, object>();

                Dictionary<string, object> timeList = (Dictionary<string, object>)dayList[s.SailingTime.Value.ToString("ddd dd")];
                if (!timeList.ContainsKey(s.SailingTime.Value.ToString("hh:mm")))
                    timeList.Add(s.SailingTime.Value.ToString("hh:mm"), s.ID);
            }

            return routeSchedules;
        }

        protected void lvSchedule_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Route r = (Route)(dataItem.DataItem);
                Label labRouteName = (Label)(dataItem.FindControl("labRouteName"));
                labRouteName.Text = "1 : " + r.ArriavlPort.PortName + " - " + r.DeparturePort.PortName;

                

                DropDownList ddlYear = (DropDownList)(dataItem.FindControl("ddlYear"));
                DropDownList ddlMonth = (DropDownList)(dataItem.FindControl("ddlMonth"));
                DropDownList ddlDay = (DropDownList)(dataItem.FindControl("ddlDay"));
                DropDownList ddlTime = (DropDownList)(dataItem.FindControl("ddlTime"));
                ddlYear.Items.Add(new ListItem("-Select-", ""));
                ddlMonth.Items.Add(new ListItem("-Select-", ""));
                ddlDay.Items.Add(new ListItem("-Select-", ""));
                ddlTime.Items.Add(new ListItem("-Select-", ""));
                Hashtable htSchedulePreLoad = (Hashtable)(Session[SessionVariable.RouteSchedules]);
                Dictionary<string, object> routeSchedules = (Dictionary<string, object>)(htSchedulePreLoad[r.ID.ToString()]);
                foreach (string key in routeSchedules.Keys)
                {
                    ddlYear.Items.Add(new ListItem(key, r.ID.ToString()));
                }

            }
        }

        protected void lvPassenger_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                RouteOrderPassengerDetail pd = (RouteOrderPassengerDetail)(dataItem.DataItem);
                Label labPassengerNo = (Label)(dataItem.FindControl("labPassengerNo"));
                labPassengerNo.Text = dataItem.DisplayIndex.ToString();

                TextBox txtPassengerAge = (TextBox)(dataItem.FindControl("txtPassengerAge"));
                txtPassengerAge.Text = pd.Age.ToString();

            }
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlYear = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlYear"));
            DropDownList ddlMonth = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlMonth"));
            DropDownList ddlDay = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlDay"));
            DropDownList ddlTime = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlTime"));
            Label labArrivalDate = (Label)(((DropDownList)sender).Parent.FindControl("labArrivalDate"));

            string routeIdStr = ddlYear.SelectedValue;

            Hashtable htSchedulePreLoad = (Hashtable)(Session[SessionVariable.RouteSchedules]);
            Dictionary<string, object> routeSchedules = (Dictionary<string, object>)(htSchedulePreLoad[routeIdStr]);

            ddlMonth.SelectedIndex = 0;
            ddlMonth.Enabled = false;
            ddlMonth.Items.Clear();
            ddlMonth.Items.Add(new ListItem("-Select-", ""));

            ddlDay.SelectedIndex = 0;
            ddlDay.Enabled = false;
            ddlDay.Items.Clear();
            ddlDay.Items.Add(new ListItem("-Select-", ""));

            ddlTime.SelectedIndex = 0;
            ddlTime.Enabled = false;
            ddlTime.Items.Clear();
            ddlTime.Items.Add(new ListItem("-Select-", ""));

            labArrivalDate.Text = "";

            if (ddlYear.SelectedIndex == 0)
            {    
                  return;
            }
            Dictionary<string, object> monthList = (Dictionary<string, object>)(routeSchedules[ddlYear.SelectedItem.Text]);
            foreach (string key in monthList.Keys)
            {
                ddlMonth.Items.Add(new ListItem(key, routeIdStr));
            }
            ddlMonth.Enabled = true;

        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlYear = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlYear"));
            DropDownList ddlMonth = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlMonth"));
            DropDownList ddlDay = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlDay"));
            DropDownList ddlTime = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlTime"));
            Label labArrivalDate = (Label)(((DropDownList)sender).Parent.FindControl("labArrivalDate"));

            string routeIdStr = ddlYear.SelectedValue;

            Hashtable htSchedulePreLoad = (Hashtable)(Session[SessionVariable.RouteSchedules]);
            Dictionary<string, object> routeSchedules = (Dictionary<string, object>)(htSchedulePreLoad[routeIdStr]);

            
            ddlDay.SelectedIndex = 0;
            ddlDay.Enabled = false;
            ddlDay.Items.Clear();
            ddlDay.Items.Add(new ListItem("-Select-", ""));

            ddlTime.SelectedIndex = 0;
            ddlTime.Enabled = false;
            ddlTime.Items.Clear();
            ddlTime.Items.Add(new ListItem("-Select-", ""));

            labArrivalDate.Text = "";

            if (ddlMonth.SelectedIndex == 0)
            {
                return;
            }

            Dictionary<string, object> monthList = (Dictionary<string, object>)(routeSchedules[ddlYear.SelectedItem.Text]);
            Dictionary<string, object> dayList = (Dictionary<string, object>)(monthList[ddlMonth.SelectedItem.Text]);
            foreach (string key in dayList.Keys)
            {
                ddlDay.Items.Add( new ListItem(key, routeIdStr));
            }
            ddlDay.Enabled = true;
        }

        protected void ddlDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlYear = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlYear"));
            DropDownList ddlMonth = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlMonth"));
            DropDownList ddlDay = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlDay"));
            DropDownList ddlTime = (DropDownList)(((DropDownList)sender).Parent.FindControl("ddlTime"));
            Label labArrivalDate = (Label)(((DropDownList)sender).Parent.FindControl("labArrivalDate"));

            string routeIdStr = ddlYear.SelectedValue;

            Hashtable htSchedulePreLoad = (Hashtable)(Session[SessionVariable.RouteSchedules]);
            Dictionary<string, object> routeSchedules = (Dictionary<string, object>)(htSchedulePreLoad[routeIdStr]);

            

            ddlTime.SelectedIndex = 0;
            ddlTime.Enabled = false;
            ddlTime.Items.Clear();
            ddlTime.Items.Add(new ListItem("-Select-", ""));
            
            labArrivalDate.Text = "";
            
            if (ddlDay.SelectedIndex == 0)
            {
                return;
            }

            Dictionary<string, object> monthList = (Dictionary<string, object>)(routeSchedules[ddlYear.SelectedItem.Text]);
            Dictionary<string, object> dayList = (Dictionary<string, object>)(monthList[ddlMonth.SelectedItem.Text]);
            Dictionary<string, object> timeList = (Dictionary<string, object>)(dayList[ddlDay.SelectedItem.Text]);
            foreach (string key in timeList.Keys)
            {
                ddlTime.Items.Add(new ListItem(key, timeList[key].ToString()));
            }
            ddlTime.Enabled = true;
        }

        protected void ddlTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlTime =(DropDownList)sender;
            Label labArrivalDate = (Label)(ddlTime.Parent.FindControl("labArrivalDate"));
            if (ddlTime.SelectedIndex > 0)
            {
                int scheduleId = Convert.ToInt32(ddlTime.SelectedValue);
                Schedule schedule = new Schedule().GetById(scheduleId, false);

                labArrivalDate.Text = "Arrival date:" + schedule.ArrivalTime.Value.ToString("ddd dd MMMM yyyy, hh:mm");
            }
            else
                labArrivalDate.Text = "";
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            //todo: validation
            
            if (Session[SessionVariable.BookingInstance] is Booking)
            {
                //update booking instance already exists in session
            }
            else
            {
                //create new booking instance to store the booking information
                Booking newBookingInstace = new Booking();

                foreach (ListViewDataItem item in lvSchedule.Items)
	            {
                    DropDownList ddlTime = (DropDownList)(item.FindControl("ddlTime"));
                    RouteOrder routeOrder = new RouteOrder();
                    routeOrder.ScheduleId = Convert.ToInt32(ddlTime.SelectedValue);
                    newBookingInstace.RouteOrders.Add(routeOrder);
	            }

                foreach (ListViewDataItem item in lvPassenger.Items)
                {
                    TextBox txtPassengerAge = (TextBox)(item.FindControl("txtPassengerAge"));
                    RouteOrderPassengerDetail passengerDetail = new RouteOrderPassengerDetail();
                    passengerDetail.Age = Convert.ToInt32(txtPassengerAge.Text);
                    newBookingInstace.RouteOrders[0].RouteOrderDetails.Add(passengerDetail);
                }

                Session[SessionVariable.BookingInstance] = newBookingInstace;
            }
        }


        

       
    }
}
