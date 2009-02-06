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
    public partial class QuoteSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session[ByteCore.FerryBooking.Web.SessionVariable.Step1UserInput] is Step1UserInput))
            {
                Response.Redirect("Default.aspx");
            }

            if (!IsPostBack)
            {                
                if (Session[SessionVariable.BookingInstance] is Booking)
                {                    
                    Booking bookingInstance = (Booking)Session[SessionVariable.BookingInstance];
                    this.lblTotalPrice.Text = bookingInstance.TotalAmount.ToString("c") + " USD";
                    lvSummary.DataSource = bookingInstance.RouteOrders;
                    lvSummary.DataBind();
                }
            }
        }

        protected void lvSummary_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                RouteOrder r = (RouteOrder)(dataItem.DataItem);
                
                Label lblRouteTotal = (Label)(dataItem.FindControl("lblRouteTotal"));
                lblRouteTotal.Text = r.RouteTotalAmount.ToString("c") + " USD";
                
                Label lblRouteName = (Label)(dataItem.FindControl("lblRouteName"));
                Route route = new Route().GetRouteBySchedule(r.ScheduleId.Value);
                lblRouteName.Text = route.DeparturePort.PortName + " - " + route.ArriavlPort.PortName;
                
                Schedule schedule = new Schedule().GetById(r.ScheduleId.Value, false);
                Label lblVesselName = (Label)(dataItem.FindControl("lblVesselName"));
                lblVesselName.Text = schedule.Vessel.VesselName;

                Vessel vessel = new Vessel().GetById(schedule.VesselId.Value, false);
                Label lblCompanyName = (Label)(dataItem.FindControl("lblCompanyName"));
                lblCompanyName.Text = vessel.Operator.CompanyName;

                Label lblDepartureDatetime = (Label)(dataItem.FindControl("lblDepartureDatetime"));
                lblDepartureDatetime.Text = schedule.SailingTime.HasValue ? schedule.SailingTime.Value.ToString() : string.Empty;

                Label lblArrivalDatetime = (Label)(dataItem.FindControl("lblArrivalDatetime"));
                lblArrivalDatetime.Text = schedule.ArrivalTime.HasValue ? schedule.ArrivalTime.Value.ToString() : string.Empty;

                Label lblPassenger = (Label)(dataItem.FindControl("lblPassenger"));
                Label lblTransport = (Label)(dataItem.FindControl("lblTransport"));
                Label lblAccommodation = (Label)(dataItem.FindControl("lblAccommodation"));
                

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Accommodation.aspx");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("PassengerDetail.aspx");
        }
    }
}
