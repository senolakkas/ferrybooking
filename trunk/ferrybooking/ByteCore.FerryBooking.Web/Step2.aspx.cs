using System;
using System.Collections;
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
    public partial class Step2 : System.Web.UI.Page
    {
        private ScheduleList route1ScheduleList;
        private Hashtable route1ScheduleHt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session[SessionVariable.Step1UserInput] is Step1UserInput))
            {
                Response.Redirect("Default.aspx");
            }
            Step1UserInput step1 = (Step1UserInput)Session[SessionVariable.Step1UserInput];
            if (!Page.IsPostBack)
            {
                route1ScheduleList = new Schedule().GetScheduleListForRoute(step1.Route1Id, new DateTime(2008,6,1));
                Route r = new Route().GetById(step1.Route1Id,false);
                labRouteName1.Text ="1 : " + r.ArriavlPort.PortName + " - " + r.DeparturePort.PortName;
                
                route1ScheduleHt =new Hashtable();
                foreach (Schedule s in route1ScheduleList)
                {
                    if (!route1ScheduleHt.ContainsKey(s.SailingTime.Value.Year.ToString()))
                        route1ScheduleHt.Add(s.SailingTime.Value.Year.ToString(),null);
                    if (route1ScheduleHt[s.SailingTime.Value.Year.ToString()] == null)
                        route1ScheduleHt[s.SailingTime.Value.Year.ToString()] = new Hashtable();

                    Hashtable monthHt = (Hashtable)route1ScheduleHt[s.SailingTime.Value.Year.ToString()];
                    if (!monthHt.ContainsKey(s.SailingTime.Value.ToString("MMMM")))
                        monthHt.Add(s.SailingTime.Value.ToString("MMMM"), null);
                    if (monthHt[s.SailingTime.Value.ToString("MMMM")] == null)
                        monthHt[s.SailingTime.Value.ToString("MMMM")] = new Hashtable();
                    
                    Hashtable dayHt = (Hashtable)monthHt[s.SailingTime.Value.ToString("MMMM")];
                    if (!dayHt.ContainsKey(s.SailingTime.Value.Day.ToString()))
                        dayHt.Add(s.SailingTime.Value.Day.ToString(), null);
                    if (dayHt[s.SailingTime.Value.Day.ToString()] == null)
                        dayHt[s.SailingTime.Value.Day.ToString()] = new Hashtable();

                    Hashtable timeHt = (Hashtable)dayHt[s.SailingTime.Value.Day.ToString()];
                    if (!timeHt.ContainsKey(s.SailingTime.Value.ToString("hh:mm")))
                        timeHt.Add(s.SailingTime.Value.ToString("hh:mm"), s);
                }
                Session[SessionVariable.Route1Schedules] = route1ScheduleHt;
                ddlYear1.Items.Add(new ListItem("-Select-", ""));
                ddlMonth1.Items.Add(new ListItem("-Select-", ""));
                ddlDay1.Items.Add(new ListItem("-Select-", ""));
                ddlTime1.Items.Add(new ListItem("-Select-", ""));

                foreach (string key in route1ScheduleHt.Keys)
                {
                    ddlYear1.Items.Add(new ListItem(key,key));
                }


                
            }
        }

        protected void ddlYear1_SelectedIndexChanged(object sender, EventArgs e)
        {
            route1ScheduleHt = (Hashtable)Session[SessionVariable.Route1Schedules];
            ddlMonth1.SelectedIndex = 0;
            ddlMonth1.Enabled = false;
            ddlDay1.SelectedIndex = 0;
            ddlDay1.Enabled = false;
            ddlTime1.SelectedIndex = 0;
            ddlTime1.Enabled = false;

            if (ddlYear1.SelectedIndex == 0)
            {    
                  return;
            }

            foreach (string key in ((Hashtable)route1ScheduleHt[ddlYear1.SelectedValue]).Keys)
            {
                ddlMonth1.Items.Add(new ListItem(key,key));
            }


        }
    }
}
