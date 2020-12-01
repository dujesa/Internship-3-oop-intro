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
        public List<Attendee> Attendees { get; set; }

        public bool IsValid()
        {
            return (Name.Length > 0 && StartTime < EndTime);
        }

        public bool IsActive()
        {
            return (StartTime <= DateTime.Now && EndTime >= DateTime.Now);
        }
    }
}
