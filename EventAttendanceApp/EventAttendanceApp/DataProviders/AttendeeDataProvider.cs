using EventAttendanceApp.Models;
using EventAttendanceApp.Repositories;
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

        public static Attendee? ProvideAttendee(List<Attendee> attendees)
        {
            var isAttendeeInputDone = false;
            Attendee foundAttendee = null;

            while (isAttendeeInputDone == false)
            {
                Console.WriteLine();
                Console.WriteLine("Molimo vas unesite OIB osobe:");

                var queryPin = Console.ReadLine();
                foundAttendee = AttendeeRepository.GetByPIN(attendees, queryPin);

                if (foundAttendee is Attendee == false)
                {
                    Console.WriteLine($"Osoba sa OIB-om ({queryPin}) nije trenutno prijavljena na odabrani event.");
                    isAttendeeInputDone = (UserDialogDataProvider.IsActionRepeatRequested() == false);
                }
                else
                {
                    isAttendeeInputDone = true;
                }

                Console.WriteLine();
            }

            return foundAttendee;
        }
    }
}