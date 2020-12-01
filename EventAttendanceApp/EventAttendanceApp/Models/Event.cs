using System;
using System.Collections.Generic;
using System.Text;

namespace EventAttendanceApp.Models
{
    public class Event
    {
        public string Name { get; set; }
        public EventType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
