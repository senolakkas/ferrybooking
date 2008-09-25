using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;
using System.Data;
using System.Collections;

namespace ByteCore.FerryBooking.Core
{
     partial class Route
     {
         public string FullName
         {
             get
             {
                 return this.DeparturePort.PortName + " - " + this.ArriavlPort.PortName + "(" + this.Operator.CompanyShortName + ")";
             }
         }

         public RouteList GetAllList()
         {
             OQL oql = new OQL(typeof(Route));
             oql.OrderBy(Route.Properties.OperatorId)
                 .OrderBy(Route.Properties.DeparturePortId)
                 .OrderBy(Route.Properties.ArriavlPortId);

             return new Route().GetList(oql);
         }

         public RouteList GetRouteList(int operatorId)
         {
             OQL oql = new OQL(typeof(Route));
             if (operatorId != 0)
                 oql.AddCondition(Condition.Eq(Route.Properties.OperatorId, operatorId));

             oql.OrderBy(Route.Properties.DeparturePortId)
                 .OrderBy(Route.Properties.ArriavlPortId);

             return new Route().GetList(oql);
         }

         public DataTable GetRouteTable()
         {
             OQL oql = new OQL(typeof(Route));
             oql.AddAssociation("Operator");
             oql.AddAssociation("DeparturePort");
             oql.AddAssociation("ArriavlPort");
             oql.SelectProperty(Route.Properties.ID);
             oql.SelectProperty("Operator." + Company.Properties.ID);
             oql.SelectProperty("Operator." + Company.Properties.CompanyShortName);
             oql.SelectProperty("DeparturePort." + Port.Properties.PortName);
             oql.SelectProperty("ArriavlPort." + Port.Properties.PortName);
             oql.AddCondition(Condition.Disjunction()
                    .AddCondition(Condition.IsNull(Route.Properties.IsActive))
                    .AddCondition(Condition.Eq(Route.Properties.IsActive, true))
                    );
             oql.OrderBy("DeparturePort." + Port.Properties.PortName)
                 .OrderBy("ArriavlPort." + Port.Properties.PortName);
             DataTable dt = Dao.GetTable(oql);
             return dt;
         }

         public List<KeyValuePair<string, string>> GetKeyValueList()
         {
             DataTable dt = this.GetRouteTable();
             List<KeyValuePair<string, string>> routeList = new List<KeyValuePair<string, string>>();
             Hashtable ht = new Hashtable();
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 string key = dt.Rows[i]["ID"].ToString() + "_" + dt.Rows[i]["Operator_ID"].ToString();
                 string value = dt.Rows[i]["DeparturePort_PortName"].ToString() + " - " + dt.Rows[i]["ArriavlPort_PortName"].ToString();
                 KeyValuePair<string, string> kv;
                 if (!ht.ContainsKey(value))
                 {
                     kv = new KeyValuePair<string, string>(key, value);
                     ht.Add(value, value);
                 }
                 else
                 {
                     kv = new KeyValuePair<string, string>(key,value + " (" + dt.Rows[i]["Operator_CompanyShortName"].ToString() + ")");
                 }
                 
                 routeList.Add(kv);
             }
             return routeList;
         }

         public static void DoInsert(Route route)
         {
             route.Create();
         }

         public void DoUpdate(int ID, int operatorId, string departurePortId, string arrivalPortId)
         {
             Route route = new Route().GetById(ID, true);
             route.OperatorId = operatorId;
             route.DeparturePortId = departurePortId;
             route.ArriavlPortId = arrivalPortId;
             route.Update();
         }

         public void DoDelete(int ID)
         {
             Route route = new Route().GetById(ID, false);
             route.Delete();
         }

         public static Route GetRouteByPortId(string depPortId, string arrPortId, int operatorId)
         {
             OQL oql = new OQL(typeof(Route));
             if (string.IsNullOrEmpty(depPortId) || string.IsNullOrEmpty(arrPortId) || operatorId <= 0)
                 return null;
             
             oql.AddCondition(Condition.Eq(Route.Properties.OperatorId, operatorId));
             oql.AddCondition(Condition.Eq(Route.Properties.DeparturePortId, depPortId));
             oql.AddCondition(Condition.Eq(Route.Properties.ArriavlPortId, arrPortId));

             RouteList list = new Route().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else if (list.Count > 1)
                 throw new Exception("Duplicate route with same operator, departure port and arrival port found.");
             else
                 return null;
         }
     }
}
