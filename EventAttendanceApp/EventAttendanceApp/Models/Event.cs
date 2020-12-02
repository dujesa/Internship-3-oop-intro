using System;

namespace EventAttendanceApp.Models
{
    public class Event
    {
        public Event(string name, DateTime startTime, DateTime endTime, int eventType)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Type = (EventType)eventType;
        }
        public string Name { get; set; }
        public EventType Type { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsActive()
        {
            return (StartTime <= DateTime.Now && EndTime >= DateTime.Now);
        }

        public override string ToString()
        {
            return string.Format("[{0}] {1}\n\t {2} - {3}", Type, Name, StartTime, EndTime);
        }
    }
}
