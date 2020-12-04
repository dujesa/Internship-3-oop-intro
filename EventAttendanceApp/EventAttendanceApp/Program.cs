using System;
using System.Collections.Generic;
using EventAttendanceApp.DataProviders;
using EventAttendanceApp.DataSeeders;
using EventAttendanceApp.Factories;
using EventAttendanceApp.Models;
using EventAttendanceApp.Repositories;

namespace EventAttendanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(200, 50);

            var events = DummyDataSeeder.seedEvents();
            int userInput;

            Console.WriteLine("Dobrodošli u Event attendance aplikaciju.");

            do
            {
                userInput = UserDialogDataProvider.FetchUsersInputFromMenu();
                Console.Clear();

                switch (userInput)
                {
                    case 0:
                        DisplayAllEvents(events);
                        break;
                    case 1:
                        AddEvent(events);
                        break;
                    case 2:
                        DeleteEvent(events);
                        break;
                    case 3:
                        EditEvent(events);
                        break;
                    case 4:
                        RegisterAttendee(events);
                        break;
                    case 5:
                        break;
                    case 6:
                        HandleEventReviewDisplay(events);
                        break;
                }

                Console.WriteLine();

            } while (userInput != 7);

            Console.WriteLine("Hvala na korištenju Playlist aplikacije.");
        }

        private static void AddEvent(Dictionary<Event, List<Attendee>> events)
        {
            var newEvent = EventFactory.CreateNew(events);

            events.Add(newEvent, null);
        }

        private static void DeleteEvent(Dictionary<Event, List<Attendee>> events)
        {
            if (events.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan rezerviran event trenutno.");

                return;
            }

            DisplayAllEventsNames(events);

            Console.WriteLine("Molimo vas unesite ime eventa kojeg želite izbrisati:");
            var queryName = Console.ReadLine();

            var foundEvent = EventRepository.GetByName(events, queryName);

            if (foundEvent is Event)
            {
                if (UserDialogDataProvider.ConfirmAction() == false)
                {
                    return;
                }

                events.Remove(foundEvent);
            }
            else
            {
                Console.WriteLine($"Event pod imenom {queryName} nije pronađen.");
            }
        }

        private static void EditEvent(Dictionary<Event, List<Attendee>> events)
        {
            if (events.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan rezerviran event trenutno.");

                return;
            }

            DisplayAllEventsNames(events);

            Console.WriteLine("Molimo vas unesite ime eventa kojeg želite urediti:");
            var queryName = Console.ReadLine();
            Console.Clear();

            var foundEvent = EventRepository.GetByName(events, queryName);

            if (foundEvent is Event == false)
            {
                Console.WriteLine($"Event pod imenom {queryName} nije pronađen.");

                return;
            }

            Console.WriteLine("Podaci eventa kojeg uređujete:");
            Console.WriteLine(foundEvent.ToString());
            Console.WriteLine();

            var isEdittingDone = false;

            while (isEdittingDone == false)
            {
                Console.Clear();

                var editFieldInput = EventDataProvider.ProvideEditEventFieldInput();
                isEdittingDone = HandleEditEventField(editFieldInput, foundEvent, events);
            }
        }

        private static void DisplayAllEvents(Dictionary<Event, List<Attendee>> events)
        {
            Console.WriteLine("Svi eventi:");

            var eventsEnumerator = events.GetEnumerator();
            eventsEnumerator.MoveNext();

            for (int i = 0; i < events.Count; i++)
            {
                var eventsAndAttendees = eventsEnumerator.Current;
                Console.WriteLine(eventsAndAttendees.Key.ToString());

                eventsEnumerator.MoveNext();
                Console.WriteLine();
            }
        }

        private static bool HandleEditEventField(int edittingField, Event edittingEvent, Dictionary<Event, List<Attendee>> allEvents)
        {
            var isEdittingDone = false;

            switch (edittingField)
            {
                case 0:
                    var newName = EventDataProvider.ProvideName();
                    if (UserDialogDataProvider.ConfirmAction() == true)
                    {
                        edittingEvent.Name = newName;
                    }
                    break;
                case 1:
                    var newType = EventDataProvider.ProvideType();
                    if (UserDialogDataProvider.ConfirmAction() == true)
                    {
                        edittingEvent.Type = (EventType)newType;
                    }
                    break;
                case 2:
                    var newDuration = EventDataProvider.ProvideDuration(allEvents);
                    if (UserDialogDataProvider.ConfirmAction() == true)
                    {
                        edittingEvent.StartTime = newDuration["startTime"];
                        edittingEvent.EndTime = newDuration["endTime"];
                    }
                    break;
                default:
                    isEdittingDone = true;
                    break;
            }

            return isEdittingDone;
        }
        
        private static void DisplayAllEventsNames(Dictionary<Event, List<Attendee>> events)
        {
            Console.WriteLine("Ispis svih evenata po imenima:");
            Console.WriteLine();

            var eventsEnumerator = events.GetEnumerator();
            eventsEnumerator.MoveNext();

            for (int i = 0; i < events.Count; i++)
            {
                var eventAndAttendees = eventsEnumerator.Current;
                Console.WriteLine(eventAndAttendees.Key.Name);

                eventsEnumerator.MoveNext();
            }

            Console.WriteLine();
        }

        private static void HandleEventReviewDisplay(Dictionary<Event, List<Attendee>> events)
        {
            int userInput;

            do
            {
                userInput = UserDialogDataProvider.FetchUsersInputFromEventDetailsSubmenu();
                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        DisplayEventDetails(events);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                }

                Console.WriteLine();
            } while (userInput != 4);
        }
        private static void DisplayEventDetails(Dictionary<Event, List<Attendee>> events)
        {
            DisplayAllEventsNames(events);

            Console.WriteLine("Molimo vas unesite ime eventa kojeg želite detaljnije pregledati:");
            var queryName = Console.ReadLine();

            var foundEvent = EventRepository.GetByName(events, queryName);

            if (foundEvent is Event)
            {
                Console.WriteLine(foundEvent.ToString());
            }
            else
            {
                Console.WriteLine($"Event pod imenom {queryName} nije pronađen.");
            }

            Console.WriteLine();
        }

        private static void RegisterAttendee(Dictionary<Event, List<Attendee>> events)
        {
            DisplayAllEventsNames(events);

            Console.WriteLine("Molimo vas unesite ime eventa na kojeg želite registrirati osobu:");
            var queryName = Console.ReadLine();

            var registrationEvent = EventRepository.GetByName(events, queryName);

            if (registrationEvent is Event)
            {
                if (events.TryGetValue(registrationEvent, out var attendees) == false || attendees is null)
                {
                    attendees = new List<Attendee>();
                }

                var newAttendee = AttendeeFactory.CreateNew(attendees);
                attendees.Add(newAttendee);
                events[registrationEvent] = attendees;
            }
            else
            {
                Console.WriteLine($"Event pod imenom {queryName} nije pronađen.");
            }
        }
    }
}
