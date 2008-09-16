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
                List<KeyValuePair<int, string>> routeList = new Route().GetKeyValueList();
                routeList.Insert(0, new KeyValuePair<int, string>(0, "(select route)"));
                ddlRoute1.DataSource = routeList;
                ddlRoute1.DataValueField = "Key";
                ddlRoute1.DataTextField = "Value";
                ddlRoute1.DataBind();
                ddlRoute1.SelectedIndex = 1;

                ddlRoute2.DataSource = routeList;
                ddlRoute2.DataValueField = "Key";
                ddlRoute2.DataTextField = "Value";
                ddlRoute2.DataBind();
                ddlRoute2.SelectedIndex = 0;
                ddlRoute2.Enabled = false;

                ddlRoute3.DataSource = routeList;
                ddlRoute3.DataValueField = "Key";
                ddlRoute3.DataTextField = "Value";
                ddlRoute3.DataBind();
                ddlRoute3.SelectedIndex = 0;
                ddlRoute3.Visible = false;

                ddlRoute4.DataSource = routeList;
                ddlRoute4.DataValueField = "Key";
                ddlRoute4.DataTextField = "Value";
                ddlRoute4.DataBind();
                ddlRoute4.SelectedIndex = 0;
                ddlRoute4.Visible = false;
            }
        }
    }
}
