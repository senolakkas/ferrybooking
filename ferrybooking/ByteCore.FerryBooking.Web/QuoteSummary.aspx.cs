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

                foreach (RouteOrderDetail detail in r.RouteOrderDetails)
                {

                }

            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {

        }
    }
}
