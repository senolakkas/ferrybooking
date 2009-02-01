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
    public partial class Accommodation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session[ByteCore.FerryBooking.Web.SessionVariable.Step1UserInput] is Step1UserInput))
            {
                Response.Redirect("Default.aspx");
            }

            if (Session[SessionVariable.BookingInstance] is Booking)
            {
                Booking bookingInstance = (Booking)Session[SessionVariable.BookingInstance];
                lvAccommodation.DataSource = bookingInstance.RouteOrders;
                lvAccommodation.DataBind();
            }            
        }

        protected void lvAccommodation_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                RouteOrder r = (RouteOrder)(dataItem.DataItem);
                Label lblRoute = (Label)(dataItem.FindControl("lblRoute"));
                Route route = new Route().GetRouteBySchedule(r.ScheduleId.Value);
                lblRoute.Text = route.DeparturePort.PortName+ " - " + route.ArriavlPort.PortName;

                GridView gvAccommodation = (GridView)(dataItem.FindControl("gvAccommodation"));
                if (gvAccommodation != null)
                {
                    IList<FareType> ftList = new FareType().GetAccommodationTypeBySchedule(r.ScheduleId.Value);
                    gvAccommodation.DataSource = ftList;
                    gvAccommodation.DataBind();
                }
            }
        }

        protected void gvAccommodation_ItemDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                FareType fareType = (FareType)e.Row.DataItem;
                Label lblAccommodationType = (Label)(e.Row.FindControl("lblAccommodationType"));
                lblAccommodationType.Text = fareType.FullFareTypeName;
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuoteDetails.aspx");
        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Response.Redirect("QuoteSummary.aspx");
        }
    }
}
