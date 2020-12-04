using System;
using EventAttendanceApp.Models;
using System.Collections.Generic;

namespace EventAttendanceApp.Validators
{
    public static class AttendeeDataValidator
    {
        public static bool ValidateFirstName(string firstName)
        {
            return firstName.Length > 0;
        }        
        
        public static bool ValidateLastName(string lastName)
        {
            return lastName.Length > 0;
        }

        public static bool ValidatePIN(string pin, List<Attendee> registeredAttendees)
        {
            if (pin.Length == 0)
            {
                return false;
            }

            if (registeredAttendees.Count == 0)
            {
                return true;
            }

            foreach (var registeredAttendee in registeredAttendees)
            {
                if (pin.Equals(registeredAttendee.PIN))
                {
                    Console.WriteLine();
                    Console.WriteLine("Pogreška, već postoji osoba prijavljena na event sa OIB koji ste unijeli!");
                    return false;
                }
            }

            return true;
        }        
        
        public static bool ValidatePhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length > 0;
        }
    }
}
