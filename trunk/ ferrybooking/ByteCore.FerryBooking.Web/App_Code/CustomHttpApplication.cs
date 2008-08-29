using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using log4net.Config;
namespace WashingFerry.Web
{
    /// <summary>
    /// Summary description for CustomHttpApplication
    /// </summary>
    public class CustomHttpApplication : HttpApplication
    {
        public void Application_Start(object sender, EventArgs e)
        {
            // Initialize log4net
            XmlConfigurator.Configure();

        }
    }

}