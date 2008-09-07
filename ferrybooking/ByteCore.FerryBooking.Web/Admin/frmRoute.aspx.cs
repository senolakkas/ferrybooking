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
    public partial class frmRoute : BasePage
    {
        private Route _route;
      
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                this.FV_Route.Visible = false;
            }
        }

        private void BindList()
        {
            this.ODS_RouteList.SelectParameters["operatorId"].DefaultValue = this.ddlOperator.SelectedValue.Trim();
            this.GV_RouteList.DataBind();
            this.lblMessage.Text = "";
        }

        private void BindOperator()
        {
            Company c = new Company();
            CompanyList list = c.GetAllList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.FV_Route.ChangeMode(FormViewMode.Insert);
            this.FV_Route.Visible = true;
            BindList();
        }

        protected void GV_RouteList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_RouteEdit.SelectParameters["id"].DefaultValue = this.GV_RouteList.SelectedValue.ToString();
            this.FV_Route.DataBind();
            this.FV_Route.ChangeMode(FormViewMode.Edit);
            this.FV_Route.Visible = true;
            BindList();
        }

        protected void FV_Route_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertRoute();
                    break;
                case "DoUpdate":
                    UpdateRoute(Convert.ToInt32(e.CommandArgument));
                    break;
                case "DoCancel":
                    this.FV_Route.Visible = false;
                    BindList();
                    break;
            }
        }

        private void InsertRoute()
        {
            int operatorId;
            string departurePortId;
            string arrivalPortId;            

            DropDownList ddlOperator = (DropDownList)this.FV_Route.FindControl("ddlOperator");
            DropDownList ddlDeparturePort = (DropDownList)this.FV_Route.FindControl("ddlDeparturePort");
            DropDownList ddlArrivalPort = (DropDownList)this.FV_Route.FindControl("ddlArrivalPort");

            operatorId = (ddlOperator == null) ? 0 : Convert.ToInt32(ddlOperator.SelectedValue);
            departurePortId = (ddlDeparturePort == null) ? "" : ddlDeparturePort.SelectedValue;
            arrivalPortId = (ddlArrivalPort == null) ? "" : ddlArrivalPort.SelectedValue;

            _route = new Route();
            _route.OperatorId = operatorId;
            _route.DeparturePortId = departurePortId;
            _route.ArriavlPortId = arrivalPortId;

            Route.DoInsert(_route);

            BindList();

            if (ddlOperator != null)
                ddlOperator.SelectedIndex = 0;
            if (ddlDeparturePort != null)
                ddlDeparturePort.SelectedIndex = 0;
            if (ddlArrivalPort != null)
                ddlArrivalPort.SelectedIndex = 0;

            this.lblMessage.Text = "Insert successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        private void UpdateRoute(int id)
        {
            int operatorId;
            string departurePortId;
            string arrivalPortId;

            DropDownList ddlOperator = (DropDownList)this.FV_Route.FindControl("ddlOperator");
            DropDownList ddlDeparturePort = (DropDownList)this.FV_Route.FindControl("ddlDeparturePort");
            DropDownList ddlArrivalPort = (DropDownList)this.FV_Route.FindControl("ddlArrivalPort");

            operatorId = (ddlOperator == null) ? 0 : Convert.ToInt32(ddlOperator.SelectedValue);
            departurePortId = (ddlDeparturePort == null) ? "" : ddlDeparturePort.SelectedValue;
            arrivalPortId = (ddlArrivalPort == null) ? "" : ddlArrivalPort.SelectedValue;

            Route route = new Route();
            route.DoUpdate(id, operatorId, departurePortId, arrivalPortId);
            BindList();

            if (ddlOperator != null)
                ddlOperator.SelectedIndex = 0;
            if (ddlDeparturePort != null)
                ddlDeparturePort.SelectedIndex = 0;
            if (ddlArrivalPort != null)
                ddlArrivalPort.SelectedIndex = 0;

            this.lblMessage.Text = "Update successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        protected void GV_RouteList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.FV_Route.Visible = false;
            this.lblMessage.Text = "Delete successfully";
            this.lblMessage.ForeColor = Color.Green;
            BindList();
        }
    }
}
