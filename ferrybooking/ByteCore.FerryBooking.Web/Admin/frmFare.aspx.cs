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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        private void BindList()
        {
            this.ODS_FareList.SelectParameters["operatorId"].DefaultValue = this.ddlOperator.SelectedValue;
            this.ODS_FareList.SelectParameters["routeId"].DefaultValue = this.ddlRoute.SelectedValue;
            this.ODS_FareList.SelectParameters["startDate"].DefaultValue = this.txtStartDate.Text.Trim();
            this.ODS_FareList.SelectParameters["endDate"].DefaultValue = this.txtEndDate.Text.Trim();            
            this.GV_FareList.DataBind();
            this.lblMessage.Text = "";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void GV_FareList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindList();

        }

        protected void GV_FareList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            BindList();
        }

        protected void ddlOperator_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }
    }
}
