using System;
using System.Collections.Generic;

namespace MyScheduleAppWP7v1
{
    public class MyDefinedEvents
    {

        public List<Event> ListEvents = new List<Event>();

        public MyDefinedEvents()
        {
            int id = 0;
            int day = 1;

            //September, 1, 2012 
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the sales manager",
                DateFrom = new DateTime(2012, 9, day, 8, 0, 0),
                DateTo = new DateTime(2012, 9, day, 8, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the CEO",
                DateFrom = new DateTime(2012, 9, day, 8, 30, 0),
                DateTo = new DateTime(2012, 9, day, 9, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the new project",
                DateFrom = new DateTime(2012, 9, day, 9, 30, 0),
                DateTo = new DateTime(2012, 9, day, 12, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for lunch",
                DateFrom = new DateTime(2012, 9, day, 12, 0, 0),
                DateTo = new DateTime(2012, 9, day, 13, 0, 0),
                EventPlace = "in Japanese restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "giving an overview about the future projects",
                DateFrom = new DateTime(2012, 9, day, 13, 0, 0),
                DateTo = new DateTime(2012, 9, day, 15, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "discuss about the different projects",
                DateFrom = new DateTime(2012, 9, day, 15, 0, 0),
                DateTo = new DateTime(2012, 9, day, 17, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go to theater with my child",
                DateFrom = new DateTime(2012, 9, day, 17, 0, 0),
                DateTo = new DateTime(2012, 9, day, 18, 30, 0),
                EventPlace = "in New Theater"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for dinner",
                DateFrom = new DateTime(2012, 9, day, 18, 30, 0),
                DateTo = new DateTime(2012, 9, day, 20, 0, 0),
                EventPlace = "in The Blue Sea Restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the tomorrow's work",
                DateFrom = new DateTime(2012, 9, day, 20, 30, 0),
                DateTo = new DateTime(2012, 9, day++, 22, 0, 0),
                EventPlace = ""
            });

            //September, 2, 2012
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the sales manager",
                DateFrom = new DateTime(2012, 9, day, 7, 30, 0),
                DateTo = new DateTime(2012, 9, day, 8, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the CEO",
                DateFrom = new DateTime(2012, 9, day, 8, 30, 0),
                DateTo = new DateTime(2012, 9, day, 9, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the new project",
                DateFrom = new DateTime(2012, 9, day, 9, 30, 0),
                DateTo = new DateTime(2012, 9, day, 12, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for lunch",
                DateFrom = new DateTime(2012, 9, day, 12, 0, 0),
                DateTo = new DateTime(2012, 9, day, 13, 0, 0),
                EventPlace = "in Japanese restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "giving an overview about the future projects",
                DateFrom = new DateTime(2012, 9, day, 13, 0, 0),
                DateTo = new DateTime(2012, 9, day, 15, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "discuss about the different projects",
                DateFrom = new DateTime(2012, 9, day, 15, 0, 0),
                DateTo = new DateTime(2012, 9, day, 17, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go to theater with my child",
                DateFrom = new DateTime(2012, 9, day, 17, 0, 0),
                DateTo = new DateTime(2012, 9, day, 18, 30, 0),
                EventPlace = "in New Theater"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for dinner",
                DateFrom = new DateTime(2012, 9, day, 18, 30, 0),
                DateTo = new DateTime(2012, 9, day, 20, 0, 0),
                EventPlace = "in The Blue Sea Restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the tomorrow's work",
                DateFrom = new DateTime(2012, 9, day, 20, 30, 0),
                DateTo = new DateTime(2012, 9, day++, 22, 0, 0),
                EventPlace = ""
            });

            //September, 3, 2012
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the sales manager",
                DateFrom = new DateTime(2012, 9, day, 7, 30, 0),
                DateTo = new DateTime(2012, 9, day, 8, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the CEO",
                DateFrom = new DateTime(2012, 9, day, 8, 30, 0),
                DateTo = new DateTime(2012, 9, day, 9, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the new project",
                DateFrom = new DateTime(2012, 9, day, 9, 30, 0),
                DateTo = new DateTime(2012, 9, day, 12, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for lunch",
                DateFrom = new DateTime(2012, 9, day, 12, 0, 0),
                DateTo = new DateTime(2012, 9, day, 13, 0, 0),
                EventPlace = "in Japanese restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "giving an overview about the future projects",
                DateFrom = new DateTime(2012, 9, day, 13, 0, 0),
                DateTo = new DateTime(2012, 9, day, 15, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "discuss about the different projects",
                DateFrom = new DateTime(2012, 9, day, 15, 0, 0),
                DateTo = new DateTime(2012, 9, day, 17, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go to theater with my child",
                DateFrom = new DateTime(2012, 9, day, 17, 0, 0),
                DateTo = new DateTime(2012, 9, day, 18, 30, 0),
                EventPlace = "in New Theater"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for dinner",
                DateFrom = new DateTime(2012, 9, day, 18, 30, 0),
                DateTo = new DateTime(2012, 9, day, 20, 0, 0),
                EventPlace = "in The Blue Sea Restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the tomorrow's work",
                DateFrom = new DateTime(2012, 9, day, 20, 30, 0),
                DateTo = new DateTime(2012, 9, day++, 22, 0, 0),
                EventPlace = ""
            });

            //September, 4, 2012
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the sales manager",
                DateFrom = new DateTime(2012, 9, day, 7, 30, 0),
                DateTo = new DateTime(2012, 9, day, 8, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "meeting with the CEO",
                DateFrom = new DateTime(2012, 9, day, 8, 30, 0),
                DateTo = new DateTime(2012, 9, day, 9, 30, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the new project",
                DateFrom = new DateTime(2012, 9, day, 9, 30, 0),
                DateTo = new DateTime(2012, 9, day, 12, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for lunch",
                DateFrom = new DateTime(2012, 9, day, 12, 0, 0),
                DateTo = new DateTime(2012, 9, day, 13, 0, 0),
                EventPlace = "in Japanese restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "giving an overview about the future projects",
                DateFrom = new DateTime(2012, 9, day, 13, 0, 0),
                DateTo = new DateTime(2012, 9, day, 15, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "discuss about the different projects",
                DateFrom = new DateTime(2012, 9, day, 15, 0, 0),
                DateTo = new DateTime(2012, 9, day, 17, 0, 0),
                EventPlace = ""
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go to theater with my child",
                DateFrom = new DateTime(2012, 9, day, 17, 0, 0),
                DateTo = new DateTime(2012, 9, day, 18, 30, 0),
                EventPlace = "in New Theater"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "go for dinner",
                DateFrom = new DateTime(2012, 9, day, 18, 30, 0),
                DateTo = new DateTime(2012, 9, day, 20, 0, 0),
                EventPlace = "in The Blue Sea Restaurant"
            });
            ListEvents.Add(new Event
            {
                EventID = id++,
                EventName = "prepare for the tomorrow's work",
                DateFrom = new DateTime(2012, 9, day, 20, 30, 0),
                DateTo = new DateTime(2012, 9, day, 22, 0, 0),
                EventPlace = ""
            });
        }
    }
}
