using System;
using System.Collections.Generic;
using GreenTea.Utils;
using GreenTea.OQL;
using GreenTea.DAO;

namespace ByteCore.FerryBooking.Core
{
     partial class Schedule
     {
         public static void DoInsert(Schedule schedule)
         {
             schedule.Create();
         }

         public ScheduleList GetAllList()
         {
             OQL oql = new OQL(typeof(Schedule));
             oql.OrderBy(Schedule.Properties.VesselId).OrderBy(Schedule.Properties.FareId);
             return new Schedule().GetList(oql);
         }

         public ScheduleList GetScheduleList(int vesselId, int fareId, DateTime startTime, DateTime endTime)
         {
             OQL oql = new OQL(typeof(Schedule));
             if (vesselId != 0)
                 oql.AddCondition(Condition.Eq(Schedule.Properties.VesselId, vesselId));
             if (fareId!=0)
                 oql.AddCondition(Condition.Eq(Schedule.Properties.FareId, fareId));
             oql.AddCondition(Condition.Ge(Schedule.Properties.SailingTime, startTime));
             oql.AddCondition(Condition.Le(Schedule.Properties.SailingTime, endTime));

             oql.OrderBy(Schedule.Properties.SailingTime, OrderByDirect.Desc);

             return new Schedule().GetList(oql);
         }

         public void DoDelete(int ID)
         {
             Schedule schedule = new Schedule().GetById(ID, false);
             schedule.Delete();
         }

         public static Schedule GetScheduleByValues(int vesselId, int fareId, DateTime sailingTime, DateTime arrivalTime)
         {
             OQL oql = new OQL(typeof(Schedule));
             oql.AddCondition(Condition.Eq(Schedule.Properties.VesselId, vesselId));
             oql.AddCondition(Condition.Eq(Schedule.Properties.FareId, fareId));
             oql.AddCondition(Condition.Eq(Schedule.Properties.SailingTime, sailingTime));
             oql.AddCondition(Condition.Eq(Schedule.Properties.ArrivalTime, arrivalTime));

             ScheduleList list = new Schedule().GetList(oql);
             if (list.Count == 1)
                 return list[0];
             else if (list.Count > 1)
                 throw new Exception("Duplicate Schedule Found");
             else
                 return null;
         }
     }
}
