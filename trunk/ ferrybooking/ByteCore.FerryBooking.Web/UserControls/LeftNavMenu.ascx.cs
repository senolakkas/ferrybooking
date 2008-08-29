using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class controls_LeftNavMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //get cuurent page name
        string pagename = GetCurrentPageName();

        if (pagename == "welcome")
            hlLeftMenuItem.Text = "Home";
        else
            hlLeftMenuItem.Text = pagename;
        //assign current request to left menu item as well
        hlLeftMenuItem.NavigateUrl = HttpContext.Current.Request.Url.ToString();

    }    

    public string GetCurrentPageName() 
    {
        System.IO.FileInfo oInfo = new System.IO.FileInfo(HttpContext.Current.Request.Url.AbsolutePath); 
        return oInfo.Name.Split('.')[0];  
    } 
}
