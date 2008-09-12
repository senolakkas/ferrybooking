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

         public ScheduleList GetScheduleList(int vesselId, int fareId, string sailingTime, string arrivalTime)
         {
             OQL oql = new OQL(typeof(Schedule))               
               .AddCondition(Condition.Eq(Schedule.Properties.VesselId, vesselId))
               .AddCondition(Condition.Eq(Schedule.Properties.FareId, fareId));

             return new Schedule().GetList(oql);
         }

         public void DoDelete(int ID)
         {
             Schedule schedule = new Schedule().GetById(ID, false);
             schedule.Delete();
         }
     }
}
