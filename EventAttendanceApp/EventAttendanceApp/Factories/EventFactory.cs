using EventAttendanceApp.DataProviders;
using EventAttendanceApp.Models;
using System.Collections.Generic;

namespace EventAttendanceApp.Factories
{
    public static class EventFactory
    {
        public static Event CreateNew(Dictionary<Event, List<Attendee>> events)
        {
            var eventName = EventDataProvider.ProvideName();
            var eventType = EventDataProvider.ProvideType();
            var eventTimeData = EventDataProvider.ProvideDuration(events);

            return new Event(eventName, eventTimeData["startTime"], eventTimeData["endTime"], eventType);
        }
    }
}