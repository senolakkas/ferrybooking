using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for SessionVariable
/// </summary>

namespace ByteCore.FerryBooking.Web
{
    public class SessionVariable
    {
        public static readonly string Step1UserInput = "Step1UserInput";
        public static readonly string RouteSchedules = "RouteSchedules";
        public static readonly string BookingInstance = "BookingInstance";
    }
}
