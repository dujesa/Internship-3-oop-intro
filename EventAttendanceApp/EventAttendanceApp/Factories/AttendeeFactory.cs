using EventAttendanceApp.DataProviders;
using EventAttendanceApp.Models;
using System.Collections.Generic;

namespace EventAttendanceApp.Factories
{
    public static class AttendeeFactory
    {
        public static Attendee CreateNew(List<Attendee> registeredAttendeesForEvent)
        {
            var firstName = AttendeeDataProvider.ProvideFistName();
            var lastName = AttendeeDataProvider.ProvideLastName();
            var pin = AttendeeDataProvider.ProvidePIN(registeredAttendeesForEvent);
            var phoneNumber = AttendeeDataProvider.ProvidePhoneNumber();

            return new Attendee(firstName, lastName, pin, phoneNumber);
        }
    }
}
