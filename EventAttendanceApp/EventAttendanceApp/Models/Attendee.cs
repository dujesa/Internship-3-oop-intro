using System;
using System.Collections.Generic;
using System.Text;

namespace EventAttendanceApp.Models
{
    public class Attendee : Person
    {
        public List<Event> RegisteredEvents { get; set; }
    }
}
