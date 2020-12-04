using EventAttendanceApp.Models;
using System.Collections.Generic;

namespace EventAttendanceApp.Repositories
{
    public static class AttendeeRepository
    {
        public static Attendee? GetByPIN(List<Attendee> attendees, string pin)
        {
            foreach (var attendee in attendees)
            {
                if (pin.Equals(attendee.PIN))
                {
                    return attendee;
                }
            }

            return null;
        }
    }
}