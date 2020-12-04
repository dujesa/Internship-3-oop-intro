using System;
using System.Collections.Generic;
using EventAttendanceApp.DataProviders;
using EventAttendanceApp.DataSeeders;
using EventAttendanceApp.Factories;
using EventAttendanceApp.Models;

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
                        RegisterAttendeeOnEvent(events);
                        break;
                    case 5:
                        RemoveAttendeeFromEvent(events);
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

            events.Add(newEvent, new List<Attendee>());
        }

        private static void DeleteEvent(Dictionary<Event, List<Attendee>> events)
        {
            if (events.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan rezerviran event trenutno.");

                return;
            }

            DisplayAllEventsNames(events);

            var foundEvent = EventDataProvider.ProvideEvent(events);

            if (foundEvent is Event == false)
            {
                return;
            }
            
            if (UserDialogDataProvider.ConfirmAction() == true)
            {
                events.Remove(foundEvent);
                Console.WriteLine($"Event je uspješno izbrisan.");
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

            var foundEvent = EventDataProvider.ProvideEvent(events);

            if (foundEvent is Event == false)
            {
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

        private static void HandleEventReviewDisplay(Dictionary<Event, List<Attendee>> events)
        {
            int userInput;

            do
            {
                userInput = UserDialogDataProvider.FetchUsersInputFromEventDetailsSubmenu();
                Console.Clear();

                if (userInput == 4)
                { 
                    return;
                }

                DisplayAllEventsNames(events);
                var reviewEvent = EventDataProvider.ProvideEvent(events);

                if (reviewEvent is Event == false)
                {
                    return;
                }

                switch (userInput)
                {
                    case 1:
                        DisplayEvent(reviewEvent);
                        break;
                    case 2:
                        DisplayAttendeesByEvent(events[reviewEvent]);
                        break;
                    case 3:
                        DisplayEventAndAttendees(reviewEvent, events[reviewEvent]);
                        break;
                    default:
                        break;
                }

                Console.WriteLine();
            } while (userInput != 4);
        }

        private static void RegisterAttendeeOnEvent(Dictionary<Event, List<Attendee>> events)
        {
            Console.Clear();
            DisplayAllEventsNames(events);

            Console.WriteLine("REGISTRACIJA OSOBE NA EVENT");
            var registrationEvent = EventDataProvider.ProvideEvent(events);

            if (registrationEvent is Event == false)
            {
                return;
            }
            
            if (events.TryGetValue(registrationEvent, out var attendees) == false || attendees is null)
            {
                attendees = new List<Attendee>();
            }

            HandleRegisteringOfAttendeeOnEvent(events, registrationEvent, attendees);
        }

        private static void RemoveAttendeeFromEvent(Dictionary<Event, List<Attendee>> events)
        {
            Console.Clear();
            DisplayAllEventsNames(events);

            Console.WriteLine("ODJAVA OSOBE SA EVENTA");
            var registrationEvent = EventDataProvider.ProvideEvent(events);

            if (registrationEvent is Event == false)
            {
                return;
            }

            if (events.TryGetValue(registrationEvent, out var attendees) == false || attendees is null)
            {
                attendees = new List<Attendee>();
            }

            HandleRemovingOfAttendeeFromEvent(attendees);
        }

        private static void HandleRegisteringOfAttendeeOnEvent(Dictionary<Event, List<Attendee>> events, Event registrationEvent, List<Attendee> attendees)
        {
            var newAttendee = AttendeeFactory.CreateNew(attendees);
            attendees.Add(newAttendee);
            events[registrationEvent] = attendees;

            Console.WriteLine();
            Console.WriteLine($"{newAttendee.FirstName} {newAttendee.LastName} uspješno registriran na event {registrationEvent.Name}.");
            Console.WriteLine();
        }

        private static void HandleRemovingOfAttendeeFromEvent(List<Attendee> attendees)
        {
            if (attendees.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedna prijavljena osoba za odabrani event.");

                return;
            }

            var foundAttendee = AttendeeDataProvider.ProvideAttendee(attendees);

            if (foundAttendee is Attendee == false)
            {
                return;
            }
                
            if (UserDialogDataProvider.ConfirmAction() == false)
            {
                return;
            }

            attendees.Remove(foundAttendee);
            Console.WriteLine("Osoba uspješno uklonjena sa eventa.");
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

        private static void DisplayEvent(Event reviewEvent)
        {
            Console.WriteLine(reviewEvent.ToString());
        }

        private static void DisplayAttendeesByEvent(List<Attendee> attendees)
        {
            if (attendees.Count == 0)
            {
                Console.WriteLine("Trenutno nitko nije prijavljen na ovaj event.");

                return;
            }

            Console.WriteLine("Prijavljeni su:");
            Console.WriteLine();

            for (var i = 0; i < attendees.Count; i++)
            {
                var attendee = attendees[i];

                Console.WriteLine($"{i + 1}. {attendee.FirstName} - {attendee.LastName} - {attendee.PhoneNumber}");
            }
        }

        private static void DisplayEventAndAttendees(Event reviewEvent, List<Attendee> attendees)
        {
            DisplayEvent(reviewEvent);
            DisplayAttendeesByEvent(attendees);
        }
    }
}