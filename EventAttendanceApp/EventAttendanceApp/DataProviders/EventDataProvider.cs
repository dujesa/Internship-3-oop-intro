using EventAttendanceApp.Models;
using EventAttendanceApp.Repositories;
using EventAttendanceApp.Validators;
using System;
using System.Collections.Generic;

namespace EventAttendanceApp.DataProviders
{
    public static class EventDataProvider
    {
        public static string ProvideName()
        {
            var isEventNameValid = false;
            var name = "";
            while (isEventNameValid == false)
            {
                Console.Write("Unesite ime eventa: ");
                name = Console.ReadLine();

                isEventNameValid = EventDataValidator.ValidateName(name);
            }

            return name;
        }

        public static int ProvideType()
        {
            var isEventTypeValid = false;
            var type = -1;
            while (isEventTypeValid == false)
            {
                Console.WriteLine("Unesite broj kao tip eventa:");
                Console.WriteLine("0 - kava");
                Console.WriteLine("1 - predavanje");
                Console.WriteLine("2 - koncert");
                Console.WriteLine("3 - sat učenja");

                var isInputValid = int.TryParse(Console.ReadLine(), out type);
                if (isInputValid && EventDataValidator.ValidateType(type) == true)
                {
                    isEventTypeValid = true;
                }
                else
                {
                    Console.WriteLine("Neispravan unos tipa eventa! Molimo unesite broj od 0 do 3 kao što je prikazano u uputama.");
                    Console.WriteLine();
                }
            }

            return type;
        }

        public static Dictionary<string, DateTime> ProvideDuration(Dictionary<Event, List<Attendee>> existingEvents)
        {
            var eventTimeData = new Dictionary<string, DateTime>();
            DateTime startTime = new DateTime(), endTime = new DateTime();

            var isEventDurationValid = false;
            while (isEventDurationValid == false)
            {
                startTime = ProvideStartTime();
                endTime = ProvideEndTime();

                if (EventDataValidator.ValidateDuration(startTime, endTime) == false)
                {
                    Console.WriteLine("Neispravno trajanje eventa, završetak mora biti poslije početka eventa!"); 
                    Console.WriteLine("Molimo ponovite unos.");
                    Console.WriteLine();

                    continue;
                }

                if (EventDataValidator.ValidateOverlapping(existingEvents, startTime, endTime) == false)
                {
                    Console.WriteLine("Termin novounesenog eventa se preklapa sa već postojećim!");
                    Console.WriteLine("Molimo odaberite slobodan termin za rezervaciju eventa.");
                    Console.WriteLine();

                    continue;
                }

                isEventDurationValid = true;
            }

            eventTimeData.Add("startTime", startTime);
            eventTimeData.Add("endTime", endTime);

            return eventTimeData;
        }

        private static DateTime ProvideStartTime()
        {
            var startTime = new DateTime();
            var isEventStartTimeValid = false;
            while (isEventStartTimeValid == false)
            {
                Console.Write("Unesite vrijeme početka eventa (u formatu dd/mm/yyyy hh:mm): ");

                isEventStartTimeValid = DateTime.TryParse(Console.ReadLine(), out startTime);

                if (isEventStartTimeValid == false)
                {
                    Console.WriteLine("Neispravan format vremena početka eventa! Molimo ponovite unos.");
                    Console.WriteLine();
                }
            }

            return startTime;
        }

        private static DateTime ProvideEndTime()
        {
            var endTime = new DateTime();
            var isEventEndTimeValid = false;
            while (isEventEndTimeValid == false)
            {
                Console.Write("Unesite vrijeme završetka eventa (u formatu dd/mm/yyyy hh:mm): ");

                isEventEndTimeValid = DateTime.TryParse(Console.ReadLine(), out endTime);

                if (isEventEndTimeValid == false)
                {
                    Console.WriteLine("Neispravan format vremena završetka eventa! Molimo ponovite unos.");
                    Console.WriteLine();
                }
            }

            return endTime;
        }

        public static int ProvideEditEventFieldInput()
        {

            Console.WriteLine("Odaberite podatak koji želite izmjeniti eventu:");
            Console.WriteLine("0 - ime");
            Console.WriteLine("1 - tip");
            Console.WriteLine("2 - vrijeme trajanja");
            Console.WriteLine("3 - završi uređivanje");

            int editFieldInput = -1;


            var isEditFieldInputted = false;
            while (isEditFieldInputted == false)
            {
                isEditFieldInputted = int.TryParse(Console.ReadLine(), out editFieldInput);

                if (isEditFieldInputted == false || editFieldInput < 0 || editFieldInput > 3)
                {
                    Console.WriteLine("Neispravan unos!");
                    Console.WriteLine();

                    isEditFieldInputted = false;
                }
            }

            return editFieldInput;
        }

        public static Event? ProvideEvent(Dictionary<Event, List<Attendee>> events)
        {
            var isEventInputDone = false;
            Event foundEvent = null;

            while (isEventInputDone == false)
            {
                Console.WriteLine();
                Console.WriteLine("Molimo vas unesite ime eventa:");

                var queryName = Console.ReadLine();
                foundEvent = EventRepository.GetByName(events, queryName);

                if (foundEvent is Event == false)
                {
                    Console.WriteLine($"Event pod imenom {queryName} nije pronađen.");
                    isEventInputDone = (UserDialogDataProvider.IsActionRepeatRequested() == false);
                }
                else
                {
                    isEventInputDone = true;
                }

                Console.WriteLine();
            }

            return foundEvent;
        }
    }
}
