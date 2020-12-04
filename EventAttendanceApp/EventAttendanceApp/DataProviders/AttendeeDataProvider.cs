using EventAttendanceApp.Models;
using EventAttendanceApp.Validators;
using System;
using System.Collections.Generic;

namespace EventAttendanceApp.DataProviders
{
    public static class AttendeeDataProvider
    {
        public static string ProvideFistName()
        {
            var isFirstNameValid = false;
            var firstName = "";

            while (isFirstNameValid == false)
            {
                Console.Write("Unesite ime osobe koju prijavljujete: ");
                firstName = Console.ReadLine();

                isFirstNameValid  = AttendeeDataValidator.ValidateFirstName(firstName);
            }

            return firstName;
        }

        public static string ProvideLastName()
        {
            var isLastNameValid = false;
            var lastName = "";

            while (isLastNameValid == false)
            {
                Console.Write("Unesite prezime osobe koju prijavljujete: ");
                lastName = Console.ReadLine();

                isLastNameValid = AttendeeDataValidator.ValidateLastName(lastName);
            }

            return lastName;
        }

        public static string ProvidePIN(List<Attendee> registeredAttendees)
        {
            var isPINValid = false;
            var pin = "";

            while (isPINValid == false)
            {
                Console.Write("Unesite OIB osobe koju prijavljujete: ");
                pin = Console.ReadLine();

                isPINValid = AttendeeDataValidator.ValidatePIN(pin, registeredAttendees);
            }

            return pin;
        }

        public static string ProvidePhoneNumber()
        {
            var isPhoneNumberValid = false;
            var phoneNumber = "";

            while (isPhoneNumberValid == false)
            {
                Console.Write("Unesite broj mobitela osobe koju prijavljujete: ");
                phoneNumber = Console.ReadLine();

                isPhoneNumberValid = AttendeeDataValidator.ValidatePhoneNumber(phoneNumber);
            }

            Console.Clear();

            return phoneNumber;
        }
    }
}
