using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ByteCore.FerryBooking.Web
{
    public class Step1UserInput
    {
        RouteSelectionMode _routeSelectionMode;
        private string _route1Value;
        private string _route2Value;
        private string _route3Value;
        private string _route4Value;
        private int _passengersCount;
        private int _vehiclesCount;

        private int _route1Id;
        private int _route2Id;
        private int _route3Id;
        private int _route4Id;


        public RouteSelectionMode RouteSelectionMode
        {
            get { return _routeSelectionMode; }
            set { _routeSelectionMode = value; }
        }

        public int Route1Id
        {
            get { return _route1Id; }
        }

        public int Route2Id
        {
            get { return _route2Id; }
        }

        public int Route3Id
        {
            get { return _route3Id; }
        }

        public int Route4Id
        {
            get { return _route4Id; }
        }

        public string Route1Value
        {
            get { return _route1Value; }
            set 
            { 
                _route1Value = value;
                if (!string.IsNullOrEmpty(value) && value.IndexOf("_") != -1)
                    _route1Id = Convert.ToInt32(value.Split('_')[0]);
            }
        }

        public string Route2Value
        {
            get { return _route2Value; }
            set 
            { 
                _route2Value = value;
                if (!string.IsNullOrEmpty(value) && value.IndexOf("_") != -1)
                    _route2Id = Convert.ToInt32(value.Split('_')[0]);
            }
        }
        
        public string Route3Value
        {
            get { return _route3Value; }
            set 
            { 
                _route3Value = value;
                if (!string.IsNullOrEmpty(value) && value.IndexOf("_") != -1)
                    _route3Id = Convert.ToInt32(value.Split('_')[0]);
            }
        }

        public string Route4Value
        {
            get { return _route4Value; }
            set 
            { 
                _route4Value = value;
                if (!string.IsNullOrEmpty(value) && value.IndexOf('_') != -1)
                    _route4Id = Convert.ToInt32(value.Split('_')[0]);
            }
        }

        public int PassengersCount
        {
            get { return _passengersCount; }
            set { _passengersCount = value; }
        }

        public int VehiclesCount
        {
            get { return _vehiclesCount; }
            set { _vehiclesCount = value; }
        }
    }
}
