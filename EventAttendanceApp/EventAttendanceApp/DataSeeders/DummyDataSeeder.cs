using EventAttendanceApp.Models;
using System;
using System.Collections.Generic;

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

            var attendees = seedAttendees();

            events.Add(testEvent1, attendees);
            events.Add(testEvent2, attendees);
            events.Add(testEvent3, attendees);
            events.Add(testEvent4, attendees);
            events.Add(testEvent5, attendees);

            return events;
        }

        private static List<Attendee> seedAttendees()
        {
            var attendees = new List<Attendee>();

            var testAttendee1 = new Attendee("Bepo", "Bepovic", "1001", "0910910910");
            var testAttendee2 = new Attendee("Duje", "Dujic", "2001", "0920920920");
            var testAttendee3 = new Attendee("Vicko", "Vickovic", "1002", "0919100919");
            var testAttendee4 = new Attendee("Špiro", "Špirčić", "2002", "0910099111");

            attendees.Add(testAttendee1);
            attendees.Add(testAttendee2);
            attendees.Add(testAttendee3);
            attendees.Add(testAttendee4);

            return attendees;
        }
    }
}