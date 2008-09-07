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

namespace ByteCore.FerryBooking.Web
{
    public partial class frmCompany : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                this.FV_Operator.Visible = false;
            }
        }

        private void BindList()
        {
            //Company c = new Company();
            //CompanyList list = c.GetCompanyList(this.txtOperatorName.Text.Trim());
            //this.GV_OperatorList.DataSource = list;
            this.ODS_CompanyList.SelectParameters["companyName"].DefaultValue = this.txtOperatorName.Text.Trim();
            this.GV_OperatorList.DataBind();
            this.lblMessage.Text = "";
        }

        private void BindCurrency()
        {
            Currency c = new Currency();
            CurrencyList list = c.GetCurrencyList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.FV_Operator.ChangeMode(FormViewMode.Insert);
            this.FV_Operator.Visible = true;
            BindList();
        }

        protected void GV_OperatorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ODS_CompanyEdit.SelectParameters["id"].DefaultValue = this.GV_OperatorList.SelectedValue.ToString();
            this.FV_Operator.DataBind();
            this.FV_Operator.ChangeMode(FormViewMode.Edit);
            this.FV_Operator.Visible = true;
            BindList();
        }

        protected void FV_Operator_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DoInsert":
                    InsertOperator();
                    break;
                case "DoUpdate":
                    UpdateOperator(Convert.ToInt32(e.CommandArgument));
                    break;
                case "DoCancel":
                    //this.FV_Operator.ChangeMode(FormViewMode.ReadOnly);
                    this.FV_Operator.Visible = false;
                    BindList();
                    break;
            }
        }

        private void UpdateOperator(int id)
        {
            string operatorName;
            string operatorShortName;
            int currencyId;
            string logoImageUrl;
            string terms;
            bool isActive;

            TextBox txtName = (TextBox)this.FV_Operator.FindControl("txtName");
            TextBox txtShortName = (TextBox)this.FV_Operator.FindControl("txtShortName");
            DropDownList ddlCurrency = (DropDownList)this.FV_Operator.FindControl("ddlCurrency");
            FileUpload fuLogoImage = (FileUpload)this.FV_Operator.FindControl("FU_Logo");
            CheckBox chkIsActiive = (CheckBox)this.FV_Operator.FindControl("chkIsActive");
            TextBox txtTerms = (TextBox)this.FV_Operator.FindControl("txtTerms");

            operatorName = (txtName == null) ? "" : (string.IsNullOrEmpty(txtName.Text) ? "" : txtName.Text);
            operatorShortName = (txtShortName == null) ? "" : (string.IsNullOrEmpty(txtShortName.Text) ? "" : txtShortName.Text);
            currencyId = (ddlCurrency == null) ? 0 : Convert.ToInt32(ddlCurrency.SelectedValue);
            logoImageUrl = (fuLogoImage == null) ? "" : (string.IsNullOrEmpty(fuLogoImage.FileName) ? "" : fuLogoImage.FileName);
            terms = (txtTerms == null) ? "" : (string.IsNullOrEmpty(txtTerms.Text) ? "" : txtTerms.Text);
            isActive = (chkIsActiive == null) ? false : chkIsActiive.Checked;

            Company company = new Company();
            company.DoUpdate(id,operatorName, operatorShortName, currencyId, logoImageUrl, terms, isActive);
            BindList();

            if (txtName != null)
                txtName.Text = string.Empty;
            if (txtShortName != null)
                txtShortName.Text = string.Empty;
            if (ddlCurrency != null)
                ddlCurrency.SelectedIndex = 0;
            //if (fuLogoImage != null)
            //    fuLogoImage. = string.Empty;
            if (txtTerms != null)
                txtTerms.Text = string.Empty;
            if (chkIsActiive != null)
                chkIsActiive.Checked = true;

            this.lblMessage.Text = "Update successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        private void InsertOperator()
        {
            string operatorName;
            string operatorShortName;
            int currencyId;
            string logoImageUrl;
            string terms;
            bool isActive;

            TextBox txtName = (TextBox)this.FV_Operator.FindControl("txtName");
            TextBox txtShortName = (TextBox)this.FV_Operator.FindControl("txtShortName");
            DropDownList ddlCurrency = (DropDownList)this.FV_Operator.FindControl("ddlCurrency");
            FileUpload fuLogoImage = (FileUpload)this.FV_Operator.FindControl("FU_Logo");
            CheckBox chkIsActiive = (CheckBox)this.FV_Operator.FindControl("chkIsActive");
            TextBox txtTerms = (TextBox)this.FV_Operator.FindControl("txtTerms");

            operatorName = (txtName == null) ? "" : (string.IsNullOrEmpty(txtName.Text) ? "" : txtName.Text);
            operatorShortName = (txtShortName == null) ? "" : (string.IsNullOrEmpty(txtShortName.Text) ? "" : txtShortName.Text);
            currencyId = (ddlCurrency == null) ? 0 : Convert.ToInt32(ddlCurrency.SelectedValue);
            logoImageUrl = (fuLogoImage == null) ? "" : (string.IsNullOrEmpty(fuLogoImage.FileName) ? "" : fuLogoImage.FileName);
            terms = (txtTerms == null) ? "" : (string.IsNullOrEmpty(txtTerms.Text) ? "" : txtTerms.Text);
            isActive = (chkIsActiive == null) ? false : chkIsActiive.Checked;

            Company company = new Company();
            company.DoInsert(operatorName, operatorShortName, currencyId, logoImageUrl, terms, isActive);
            BindList();

            if (txtName != null)
                txtName.Text = string.Empty;
            if (txtShortName != null)
                txtShortName.Text = string.Empty;
            if (ddlCurrency != null)
                ddlCurrency.SelectedIndex = 0;
            //if (fuLogoImage != null)
            //    fuLogoImage. = string.Empty;
            if (txtTerms != null)
                txtTerms.Text = string.Empty;
            if (chkIsActiive != null)
                chkIsActiive.Checked = true;

            this.lblMessage.Text = "Insert successfully";
            this.lblMessage.ForeColor = Color.Green;
        }

        protected void GV_OperatorList_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            //this.FV_Operator.ChangeMode(FormViewMode.ReadOnly);
            this.FV_Operator.Visible = false;
            this.lblMessage.Text = "Delete successfully";
            this.lblMessage.ForeColor = Color.Green;
            BindList();
        }
    }
}
