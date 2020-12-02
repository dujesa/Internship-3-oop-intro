using EventAttendanceApp.Models;
using System;

namespace EventAttendanceApp.Validators
{
    class EventDataValidator
    {
        public static bool ValidateName(string eventName)
        {
            return eventName.Length > 0;
        }

        public static bool ValidateType(int eventType)
        {
            return (eventType >= 0 && eventType <= 3);
        }

        public static bool ValidateDuration(DateTime startTime, DateTime endTime)
        {
            return startTime < endTime;
        }
    }
}
