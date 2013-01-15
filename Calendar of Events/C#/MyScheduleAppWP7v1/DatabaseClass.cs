using System;
using System.Collections.Generic;
using System.Linq;

namespace MyScheduleAppWP7v1
{
    public class DatabaseClass
    {

        ScheduleDataContext EventsDB = new ScheduleDataContext(@"isostore:/EventsDB.sdf");

        private static int LastEventIndex;

        public DatabaseClass()
        {
            if (CreateDatabase())
            {
                MyDefinedEvents definedevents = new MyDefinedEvents();
                FillDatabase(definedevents.ListEvents);
            }
        }

        public Boolean CreateDatabase()
        {
            if (EventsDB.DatabaseExists() == false)
            {
                try
                {
                    EventsDB.CreateDatabase();
                    return true;
                }
                catch (Exception exc) { return false; }
            }
            else
            {
                //Events Database already exists!!!
                return false;
            }
        }

        public bool FillDatabase(List<Event> ListEvents)
        {
            LastEventIndex = 0;
            try
            {
                foreach (Event event1 in ListEvents)
                {
                    EventsDB.Events.InsertOnSubmit(event1);
                    EventsDB.SubmitChanges();
                    LastEventIndex++;
                }
                return true;
            }
            catch (Exception exc) { return false; }
        }

        public IList<Event> GetEventsList()
        {
            try
            {
                // Fetching data from local database
                IList<Event> EventsList = null;
                {
                    IQueryable<Event> EmpQuery = from Evnt in EventsDB.Events select Evnt;
                    EventsList = EmpQuery.ToList();
                }
                return EventsList;
            }
            catch (Exception exc) { return null; }
        }

        public bool AddEvent(Event evnt)
        {

            evnt.EventID = LastEventIndex + 1; //give it the biggest ID

            //evnt.EventID = EventsDB.Events.Last().EventID + 1; 
            try
            {
                EventsDB.Events.InsertOnSubmit(evnt);
                EventsDB.SubmitChanges();
                LastEventIndex++;
                return true;
            }
            catch (Exception exc) { return false; }
        }

        public bool EditEvent(Event evnt)
        {
            try
            {
            // Query for a specific Event
                IQueryable<Event> EvntQuery = from ev in EventsDB.Events where ev.EventID == evnt.EventID select ev;
                //Event evntEdit = EvntQuery.FirstOrDefault();
                EvntQuery.First().DateFrom = evnt.DateFrom;
                EvntQuery.First().DateTo = evnt.DateTo;
                EvntQuery.First().EventID = evnt.EventID;
                EvntQuery.First().EventName = evnt.EventName;
                EvntQuery.First().EventPlace = evnt.EventPlace;

                EventsDB.SubmitChanges();

                return true;
            }
            catch (Exception exc) { return false; }
        }

        public bool DeleteEvent(int evntId)
        {
            try
            {
                IQueryable<Event> EvntQuery = from Evnt in EventsDB.Events where Evnt.EventID == evntId select Evnt;
                Event EvntRemove = EvntQuery.FirstOrDefault();
                EventsDB.Events.DeleteOnSubmit(EvntRemove);
                EventsDB.SubmitChanges();
                return true;
            }
            catch (Exception exc) { return false; }
        }
    }
}
