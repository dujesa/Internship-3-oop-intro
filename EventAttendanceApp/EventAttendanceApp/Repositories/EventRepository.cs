using EventAttendanceApp.Models;
using System.Collections.Generic;

namespace EventAttendanceApp.Repositories
{
    public static class EventRepository
    {
        public static Event? GetByName(Dictionary<Event, List<Attendee>> eventsAndAttendees, string name)
        { 
            IEnumerator<Event> eventEnumerator = eventsAndAttendees.Keys.GetEnumerator();
            eventEnumerator.MoveNext();

            for (int i = 0; i < eventsAndAttendees.Count; i++)
            {
                var currentEvent = eventEnumerator.Current;
                if (currentEvent.Name.Equals(name))
                {
                    return currentEvent;
                }

                eventEnumerator.MoveNext();
            }

            return null;
        }
    }
}