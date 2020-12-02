using System;

namespace EventAttendanceApp.Models
{
    public class Event
    {
        public Event(string name, DateTime startTime, DateTime endTime, int eventType)
        {
            if (Name.Length <= 0)
            {
                throw new ArgumentException("Pogreška: Ime eventa neispravno!");
            }

            if (StartTime >= EndTime)
            {
                throw new ArgumentException("Pogreška: Datum početka mora biti raniji od datuma završetka eventa!");
            }

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
    }
}
