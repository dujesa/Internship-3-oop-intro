using EventAttendanceApp.Models;
using System;
using System.Collections.Generic;

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

        public static bool ValidateOverlapping(Dictionary <Event, List<Attendee>> events, DateTime newEventStartTime, DateTime newEventEndTime)
        {
            var eventsEnumerator = events.GetEnumerator();
            eventsEnumerator.MoveNext();
            
            for (int i = 0; i < events.Count; i++)
            {
                var checkingEvent = eventsEnumerator.Current.Key;

                if (IsOverlappingWithEvent(newEventStartTime, checkingEvent) || IsOverlappingWithEvent(newEventEndTime, checkingEvent)) 
                {
                    return false;
                }

                eventsEnumerator.MoveNext();
            }

            return true;
        }

        private static bool IsOverlappingWithEvent(DateTime time, Event checkingEvent)
        {
            return (time >= checkingEvent.StartTime && time <= checkingEvent.EndTime);
        }
    }
}
