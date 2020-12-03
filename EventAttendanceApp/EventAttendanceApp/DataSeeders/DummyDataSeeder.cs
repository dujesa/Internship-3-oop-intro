using EventAttendanceApp.Factories;
using EventAttendanceApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventAttendanceApp.DataSeeders
{
    public static class DummyDataSeeder
    {
        public static Dictionary<Event, List<Attendee>> seedEvents()
        {
            var events = new Dictionary<Event, List<Attendee>>();

            for (int i = 0; i < 6; i++)
            {
                var newEvent = new Event(
                    i + ". Dummy event" ,
                    DateTime.Now.AddHours(i).AddMinutes(1),
                    DateTime.Now.AddHours(i+1),
                    i % 4
                );

                events.Add(newEvent, null);
            }

            return events;
        }
    }
}
