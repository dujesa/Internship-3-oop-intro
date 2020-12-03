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
                
            var testEvent1 = new Event("Matematika predavanje", DateTime.Now ,DateTime.Now.AddHours(2), 1);
            var testEvent2 = new Event("Kava sa profesorom iz matematike", DateTime.Now.AddDays(1) ,DateTime.Now.AddDays(1).AddHours(3), 0);
            var testEvent3 = new Event("Kendrick koncert", DateTime.Now.AddHours(2).AddMinutes(1) ,DateTime.Now.AddHours(5), 2);
            var testEvent4 = new Event("Grupno učenje fizike za kolokvij", DateTime.Now.AddDays(4) ,DateTime.Now.AddDays(7), 3);
            var testEvent5 = new Event("Sia koncert", DateTime.Now.AddDays(7).AddHours(3) ,DateTime.Now.AddDays(7).AddHours(7), 2);

            events.Add(testEvent1, null);
            events.Add(testEvent2, null);
            events.Add(testEvent3, null);
            events.Add(testEvent4, null);
            events.Add(testEvent5, null);

            return events;
        }
    }
}
