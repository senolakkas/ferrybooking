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
    public partial class frmFare : BasePage
    {
        private Fare _fare;
        private int _fareId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label lblPageTitle = this.Master.Page.Form.FindControl("lblPageTitle") as Label;
                if (lblPageTitle != null)
                    lblPageTitle.Text = "Fare";

                BindOperator();
                BindRoute();
                BindList();
                this.pnlFareItems.Visible = false;
            }
        }

        private void BindOperator()
        {
            Company c = new Company();
            CompanyList clist = c.GetAllList();
            this.ddlOperator.DataSource = clist;
            this.ddlOperator.DataTextField = "FullName";
            this.ddlOperator.DataValueField = "ID";
            this.ddlOperator.DataBind();
            this.ddlOperator.Items.Insert(0, new ListItem("-- Show All --", "0"));
        }

        private void BindRoute()
        {
            int operatorInd = Convert.ToInt32(this.ddlOperator.SelectedValue);
            Route r = new Route();
            RouteList rlist = r.GetRouteList(operatorInd);
            this.ddlRoute.DataSource = rlist;
            this.ddlRoute.DataTextField = "FullName";
            this.ddlRoute.DataValueField = "ID";
            this.ddlRoute.DataBind();
            this.ddlRoute.Items.Insert(0, new ListItem("-- Show All --", "0"));
        }

        private void BindList()
        {
            Fare fare = new Fare();
            int operatorId = 0;
            int routeId = 0; ;
            if (this.ddlOperator.SelectedIndex != -1)
                int.TryParse(this.ddlOperator.SelectedValue, out operatorId);
            if (this.ddlRoute.SelectedIndex != -1)
                int.TryParse(this.ddlRoute.SelectedValue, out routeId);
            DateTime startTime = new DateTime(1900, 1, 1);
            DateTime endTime = DateTime.MaxValue;
            DateTime.TryParse(this.txtStartDate.Text, out startTime);
            DateTime.TryParse(this.txtEndDate.Text, out endTime);
            if (startTime == DateTime.MinValue)
                startTime = new DateTime(1900, 1, 1);
            if (endTime == DateTime.MinValue)
                endTime = DateTime.MaxValue;
            if (endTime != DateTime.MaxValue)
                endTime = endTime.AddDays(1.0);
            FareList list = fare.GetFareList(operatorId,routeId, startTime, endTime);
            this.GV_FareList.DataSource = list;
            this.GV_FareList.DataBind();
            this.lblMessage.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.FV_Fare.ChangeMode(FormViewMode.Insert);
            this.FV_Fare.Visible = true;
            this.pnlFareItems.Visible = false;
            BindList();
        }

        protected void GV_FareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _fareId = Convert.ToInt32(this.GV_FareList.SelectedValue);
            Fare currentFare = new Fare().GetById(_fareId, false);
            BindFareCategory();
            BindItemList(_fareId);
            this.pnlFareItems.Visible = true;
            this.FV_Fare.Visible = false;
        }

        protected void GV_FareList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.FV_Fare.Visible = false;
            this.pnlFareItems.Visible = false;
            this.lblMessage.Text = "Delete successfully";
            this.lblMessage.ForeColor = Color.Green;
            BindList();
        }

        protected void GV_FareList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GV_FareList.PageIndex = e.NewPageIndex;
            BindList();
        }

        protected void ddlOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRoute();
            BindList();
        }

        protected void FV_Fare_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertFare();
                    break;
                case "DoUpdate":
                    UpdateFare(Convert.ToInt32(e.CommandArgument));
                    break;
                case "DoCancel":
                    this.FV_Fare.Visible = false;
                    BindList();
                    break;
            }
        }

        private void InsertFare()
        {
            int routeId;
            DateTime startDate;
            DateTime endDate;

            DropDownList ddlRoute = (DropDownList)this.FV_Fare.FindControl("ddlRoute");
            TextBox txtStartDate = (TextBox)this.FV_Fare.FindControl("txtStartDate");
            TextBox txtEndDate = (TextBox)this.FV_Fare.FindControl("txtEndDate");

            routeId = (ddlRoute == null) ? 0 : Convert.ToInt32(ddlRoute.SelectedValue);

            if (DateTime.TryParse(txtStartDate.Text.Trim(), out startDate)
                && DateTime.TryParse(txtEndDate.Text.Trim(), out endDate)
                && routeId != 0 )
            {

                _fare = new Fare();
                _fare.RoutesID = routeId;
                _fare.StartDate = startDate;
                _fare.EndDate = endDate;
                Fare.DoInsert(_fare);

                BindList();

                if (ddlRoute != null)
                    ddlRoute.SelectedIndex = 0;

                this.lblMessage.Text = "Insert successfully";
                this.lblMessage.ForeColor = Color.Green;
            }
            else
            {
                this.lblMessage.Text = "Insert failed";
                this.lblMessage.ForeColor = Color.Red;
            }
        }

        private void UpdateFare(int id)
        {
            int routeId;
            DateTime startDate;
            DateTime endDate;

            DropDownList ddlRoute = (DropDownList)this.FV_Fare.FindControl("ddlRoute");
            TextBox txtStartDate = (TextBox)this.FV_Fare.FindControl("txtStartDate");
            TextBox txtEndDate = (TextBox)this.FV_Fare.FindControl("txtEndDate");

            routeId = (ddlRoute == null) ? 0 : Convert.ToInt32(ddlRoute.SelectedValue);

            if (DateTime.TryParse(txtStartDate.Text.Trim(), out startDate)
                && DateTime.TryParse(txtEndDate.Text.Trim(), out endDate)
                && routeId != 0)
            {

                Fare fare = new Fare();
                fare.DoUpdate(id, routeId, startDate, endDate);
                BindList();

                if (ddlRoute != null)
                    ddlRoute.SelectedIndex = 0;

                this.lblMessage.Text = "Update successfully";
                this.lblMessage.ForeColor = Color.Green;
            }
            else
            {
                this.lblMessage.Text = "Update failed";
                this.lblMessage.ForeColor = Color.Red;
            }
        }

        protected void lbtnEditFare_Command(object sender, CommandEventArgs e)
        {
            this.ODS_FareEdit.SelectParameters["id"].DefaultValue = e.CommandArgument.ToString();
            this.FV_Fare.DataBind();
            this.FV_Fare.ChangeMode(FormViewMode.Edit);
            this.FV_Fare.Visible = true;
            this.pnlFareItems.Visible = false;
            BindList();
        }

        private void BindFareCategory()
        {
            FareCategory fc = new FareCategory();
            FareCategoryList fclist = fc.GetAllList();
            this.ddlFareCategory.DataSource = fclist;
            this.ddlFareCategory.DataTextField = "CategoryName";
            this.ddlFareCategory.DataValueField = "ID";
            this.ddlFareCategory.DataBind();
            this.ddlFareCategory.Items.Insert(0, new ListItem("-- Show All --", "0"));
        }

        private void BindItemList(int fareId)
        {
            FareItem fareItem = new FareItem();
            int categoryId = 0;
            if (this.ddlFareCategory.SelectedIndex != -1)
                int.TryParse(this.ddlFareCategory.SelectedValue, out categoryId);
            FareItemList list = fareItem.GetFareItemList(categoryId, fareId);
            this.GV_FareItemList.DataSource = list;
            this.GV_FareItemList.DataBind();
            this.lblSubMessage.Text = "";
        }

        protected void btnSubSearch_Click(object sender, EventArgs e)
        {
            BindItemList(_fareId);
        }

        protected void GV_FareItemList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            this.FV_FareItem.Visible = false;
            this.lblSubMessage.Text = "Delete successfully";
            this.lblSubMessage.ForeColor = Color.Green;
            BindItemList(_fareId);
        }

        protected void GV_FareItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_FareItemEdit.SelectParameters["id"].DefaultValue = this.GV_FareItemList.SelectedValue.ToString();
            this.FV_FareItem.DataBind();
            this.FV_FareItem.ChangeMode(FormViewMode.Edit);
            this.FV_FareItem.Visible = true;
            BindItemList(_fareId);
        }

        protected void GV_FareItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GV_FareItemList.PageIndex = e.NewPageIndex;
            BindItemList(_fareId);
        }

        protected void btnAddItem_Click(object sender, EventArgs e)
        {
            this.FV_FareItem.ChangeMode(FormViewMode.Insert);
            this.FV_FareItem.Visible = true;
            BindItemList(_fareId);
        }

        protected void FV_FareItem_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertFareItem();
                    break;
                case "DoUpdate":
                    UpdateFareItem(Convert.ToInt32(e.CommandArgument));
                    break;
                case "DoCancel":
                    this.FV_FareItem.Visible = false;
                    BindItemList(_fareId);
                    break;
            }
        }

        private void UpdateFareItem(int p)
        {
            return;
        }

        private void InsertFareItem()
        {
            return;
        }

        protected void FV_FareItem_PreRender(object sender, EventArgs e)
        {
            BindFareType();
        }

        private void BindFareType()
        {
            DropDownList ddlFareType = (DropDownList)this.FV_FareItem.FindControl("ddlFareType");            
            if (ddlFareType != null)
            {
                if (_fareId == 0)
                    _fareId = Convert.ToInt32(this.GV_FareItemList.SelectedValue);
                Fare fare = new Fare().GetById(_fareId, false);
                if (fare != null)
                {
                    int operatorId = fare.Routes.OperatorId.GetValueOrDefault(0);
                    FareType ft = new FareType();
                    FareTypeList list = ft.GetFareTypeList(operatorId, 0);
                    ddlFareType.DataSource = list;
                    ddlFareType.DataTextField = "FullName";
                    ddlFareType.DataValueField = "ID";
                    ddlFareType.DataBind();
                }
            }
        }
    }
}
