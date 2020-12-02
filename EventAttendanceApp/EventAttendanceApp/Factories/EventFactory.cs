using EventAttendanceApp.DataProviders;
using EventAttendanceApp.Models;

namespace EventAttendanceApp.Factories
{
    public static class EventFactory
    {
        public static Event CreateNew()
        {
            var eventName = EventDataProvider.ProvideName();
            var eventType = EventDataProvider.ProvideType();
            var eventTimeData = EventDataProvider.ProvideDuration();

            return new Event(eventName, eventTimeData["startTime"], eventTimeData["endTime"], eventType);
        }
    }
}
