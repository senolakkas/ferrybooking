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
    public partial class PassengerDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session[ByteCore.FerryBooking.Web.SessionVariable.BookingInstance] is Booking))
            {
                Response.Redirect("Default.aspx");
            }
            
            if (!IsPostBack)
            {
                Booking bookingInstance = (Booking)Session[SessionVariable.BookingInstance];
                this.LV_RouteVehicle.DataSource = bookingInstance.RouteOrders;
                this.LV_RouteVehicle.DataBind();
            }
        }

        protected void LV_RouteVehicle_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                Booking bookingInstance = (Booking)Session[SessionVariable.BookingInstance];

                Label lblRouteNo = (Label)(dataItem.FindControl("lblRouteNo"));
                lblRouteNo.Text = "Route " + (dataItem.DisplayIndex + 1).ToString();
                //HiddenField hidRouteNo = (HiddenField)(dataItem.FindControl("hidRouteNo"));
                //hidRouteNo.Value=bookingInstance.RouteOrders.r
                ListView lvVehicleDetail = (ListView)(dataItem.FindControl("LV_VehicleDetail"));
                RouteOrderVehicleDetailList vehicleList = new RouteOrderVehicleDetailList();

                Step1UserInput step1 = (Step1UserInput)Session[SessionVariable.Step1UserInput];
                //for (int i = 0; i < step1.VehiclesCount; i++)
                //for (int i = 0; i < bookingInstance.RouteOrders[0].RouteOrderDetails.Count; i++)
                foreach (RouteOrderDetail item in bookingInstance.RouteOrders[0].RouteOrderDetails)
                {
                    if (item is RouteOrderVehicleDetail)
                    {
                        //vehicleList.Add(item);
                    }
                }               

                lvVehicleDetail.DataSource = vehicleList;
                lvVehicleDetail.DataBind();
            }
        }

        protected void LV_VehicleDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                ListViewDataItem dataItem = (ListViewDataItem)e.Item;

                Label lblVehicleNo = (Label)(dataItem.FindControl("lblVehicleNo"));
                lblVehicleNo.Text = "Vehicle " + (dataItem.DisplayIndex + 1).ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            Booking bookingInstance = (Booking)Session[SessionVariable.BookingInstance];
            List<KeyValuePair<string, string>> detailList = new List<KeyValuePair<string, string>>();
            for (int i = 0; i < this.LV_RouteVehicle.Items.Count; i++)
            {
                ListView lvVehicleDetail = (ListView)this.LV_RouteVehicle.Items[i].FindControl("LV_VehicleDetail");
                for (int j = 0; j < lvVehicleDetail.Items.Count; j++)
                {
                    TextBox txtPlate = (TextBox)(lvVehicleDetail.Items[j].FindControl("txtPlate"));
                    TextBox txtModel = (TextBox)(lvVehicleDetail.Items[j].FindControl("txtModel"));
                    detailList.Add(new KeyValuePair<string, string>(i.ToString() + "_" + j.ToString(), txtPlate.Text.Trim() + "|" + txtModel.Text.Trim()));
                }
            }

            int m = 0;
            int n = 0;
            foreach (RouteOrder route in bookingInstance.RouteOrders)
            {
                foreach (RouteOrderDetail detail in route.RouteOrderDetails)
                {
                    if (detail is RouteOrderVehicleDetail)
                    {
                        RouteOrderVehicleDetail v = (RouteOrderVehicleDetail)detail;
                        foreach (KeyValuePair<string, string> item in detailList)
                        {
                            if (item.Key.Equals(m.ToString() + "_" + n.ToString()))
                            {
                                string[] str = item.Value.Split('|');
                                v.LicensePlate = str[0];
                                v.MakeModel = str[1];
                            }
                        }
                        n++;
                    }
                }
                m++;
            }
            //foreach (ListViewDataItem item in this.LV_RouteVehicle.Items)
            //{
            //    ListView lvVehicleDetail = (ListView)(item.FindControl("LV_VehicleDetail"));
            //    foreach (ListViewDataItem subitem in lvVehicleDetail.Items)
            //    {
            //        TextBox txtPlate = (TextBox)(subitem.FindControl("txtPlate"));
            //        TextBox txtModel = (TextBox)(subitem.FindControl("txtModel"));
            //        foreach (RouteOrder route in bookingInstance.RouteOrders)
            //        {
            //            foreach (RouteOrderDetail detail in route.RouteOrderDetails)
            //            {
            //                if (detail is RouteOrderVehicleDetail)
            //                {
            //                    RouteOrderVehicleDetail v = (RouteOrderVehicleDetail)detail;
            //                    v.LicensePlate = txtPlate.Text.Trim();
            //                    v.MakeModel = txtModel.Text.Trim();
            //                }
            //            }
            //        }
            //    }
            //}



        }

        protected void LV_PassengerDetail_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
    }
}
