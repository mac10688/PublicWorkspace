
using System.Data.Linq.Mapping;
using System;

namespace MyScheduleAppWP7v1
{

    [Table]
    public class Event
    {

        [Column(IsPrimaryKey = true)]
        public int EventID
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public string EventName
        {
            get;
            set;
        }

        [Column(CanBeNull = true)]
        public string EventPlace
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public DateTime DateFrom
        {
            get;
            set;
        }

        [Column(CanBeNull = false)]
        public DateTime DateTo
        {
            get;
            set;
        }
    }
}