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

namespace ByteCore.FerryBooking.Web.Admin
{
    public partial class frmCompany : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            Company c = new Company();
            CompanyList list = c.GetCompanyList(this.txtOperatorName.Text.Trim());
            this.GV_OperatorList.DataSource = list;
            this.GV_OperatorList.DataBind();

            Port port = new Port();
            PortList plist = port.GetList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindList();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

        }


    }
}
