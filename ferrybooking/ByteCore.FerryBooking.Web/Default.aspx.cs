using System;
using System.Collections;
using System.Collections.Generic;
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


namespace ByteCore.FerryBooking.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<KeyValuePair<string, string>> routeList = new Route().GetKeyValueList();
                routeList.Insert(0, new KeyValuePair<string, string>("0", "(select outward route)"));
                ddlRoute1.DataSource = routeList;
                ddlRoute1.DataValueField = "Key";
                ddlRoute1.DataTextField = "Value";
                ddlRoute1.DataBind();
                ddlRoute1.SelectedIndex = 0;


                List<KeyValuePair<string, string>> routeEmptyList = new List<KeyValuePair<string,string>>();
                routeEmptyList.Insert(0, new KeyValuePair<string, string>("0", "(select return route)"));
                ddlRoute2.DataSource = routeEmptyList;
                ddlRoute2.DataValueField = "Key";
                ddlRoute2.DataTextField = "Value";
                ddlRoute2.DataBind();
                ddlRoute2.SelectedIndex = 0;

                ddlRoute3.DataSource = routeEmptyList;
                ddlRoute3.DataValueField = "Key";
                ddlRoute3.DataTextField = "Value";
                ddlRoute3.DataBind();
                ddlRoute3.SelectedIndex = 0;

                ddlRoute4.DataSource = routeEmptyList;
                ddlRoute4.DataValueField = "Key";
                ddlRoute4.DataTextField = "Value";
                ddlRoute4.DataBind();
                ddlRoute4.SelectedIndex = 0;



                List<KeyValuePair<int, string>> passengerList = new List<KeyValuePair<int,string>>();
                passengerList.Add(new KeyValuePair<int, string>(0, "Select total passengers"));
                for (int i = 1; i < 10; i++)
                {
                    passengerList.Add(new KeyValuePair<int, string>(i, i.ToString() + " passengers"));
                }

                List<KeyValuePair<int, string>> vehicleList = new List<KeyValuePair<int, string>>();
                vehicleList.Add(new KeyValuePair<int, string>(0, "Select total vehicles"));
                for (int i = 1; i < 10; i++)
                {
                    vehicleList.Add(new KeyValuePair<int, string>(i, i.ToString() + " vehicles"));
                }

                ddlPassengers.DataSource = passengerList;
                ddlPassengers.DataValueField = "Key";
                ddlPassengers.DataTextField = "Value";
                ddlPassengers.DataBind();
                ddlPassengers.SelectedIndex = 0;

                ddlVehicles.DataSource = vehicleList;
                ddlVehicles.DataValueField = "Key";
                ddlVehicles.DataTextField = "Value";
                ddlVehicles.DataBind();
                ddlVehicles.SelectedIndex = 0;

                string jscript;
                jscript = string.Format(
                    @"
                    var route1 = document.getElementById('{0}');
                    var route2 = document.getElementById('{1}');
                    var route3 = document.getElementById('{2}');
                    var route4 = document.getElementById('{3}');
                    var passengers = document.getElementById('{4}');
                    var vehicles = document.getElementById('{5}');
                    route3.style.display = 'none';
                    route4.style.display = 'none';
                    var singleRb = document.getElementById('{6}');
                    var returnRb = document.getElementById('{7}');
                    var multiRb = document.getElementById('{8}');
                    "
                    , this.ddlRoute1.ClientID
                    ,this.ddlRoute2.ClientID
                    ,this.ddlRoute3.ClientID
                    ,this.ddlRoute4.ClientID
                    ,this.ddlPassengers.ClientID
                    ,this.ddlVehicles.ClientID
                    ,this.rbSingle.ClientID
                    ,this.rbReturn.ClientID
                    ,this.rbMulti.ClientID
                    );

                jscript += "initRouteDataSource();";


                Page.ClientScript.RegisterStartupScript(this.GetType(), "StartUp", jscript, true);

                rbReturn.Attributes.Add("onChange", "javascript:return on_rbReturn();");
                rbSingle.Attributes.Add("onChange", "javascript:return on_rbSingle();");
                rbMulti.Attributes.Add("onChange", "javascript:return on_rbMulti();");
                ddlRoute1.Attributes.Add("onChange", "javascript:return on_route1_change();");
            }
        }

        protected void rbReturn_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReturn.Checked)
            {
                this.ddlRoute2.Enabled = true;
                this.ddlRoute3.Visible = false;
                this.ddlRoute4.Visible = false;
            }
        }

        protected void rbSingle_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSingle.Checked)
            {
                this.ddlRoute2.SelectedIndex = 0;
                this.ddlRoute2.Enabled = false;
                this.ddlRoute3.Visible = false;
                this.ddlRoute4.Visible = false;

            }
        }

        protected void rbMulti_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMulti.Checked)
            {
                this.ddlRoute2.Enabled = true;
                this.ddlRoute3.Visible = true;
                this.ddlRoute4.Visible = true;
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            //store the values of each control to session
            Step1UserInput step1 = new Step1UserInput();
            if (rbSingle.Checked)
                step1.RouteSelectionMode = RouteSelectionMode.Single;
            if (rbReturn.Checked)
                step1.RouteSelectionMode = RouteSelectionMode.Return;
            if (rbMulti.Checked)
                step1.RouteSelectionMode = RouteSelectionMode.Multi;

            step1.Route1Value = ddlRoute1.SelectedValue;
            step1.Route2Value = Request.Params[ddlRoute2.ClientID];
            step1.Route3Value = Request.Params[ddlRoute3.ClientID];
            step1.Route4Value = Request.Params[ddlRoute4.ClientID];
            step1.PassengersCount = Convert.ToInt32(ddlPassengers.SelectedValue);
            step1.VehiclesCount = Convert.ToInt32(ddlVehicles.SelectedValue);
            Session[SessionVariable.Step1UserInput] = step1;
            Response.Redirect("Step2.aspx");
          
        }


    }
}
