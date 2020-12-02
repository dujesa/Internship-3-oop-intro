using System;
using System.Collections.Generic;
using EventAttendanceApp.Models;

namespace EventAttendanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            var events = new Dictionary<Event, List<Attendee>>();

            Console.WriteLine("Dobrodošli u Event attendance aplikaciju.");

            do
            {
                userInput = FetchUsersInputFromMenu();
                Console.Clear();

                switch (userInput)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                }

                Console.WriteLine();

            } while (userInput != 7);

            Console.WriteLine("Hvala na korištenju Playlist aplikacije.");
        }
        static int FetchUsersInputFromMenu()
        {
            DisplayMenu();

            if (int.TryParse(Console.ReadLine(), out var menuInput) == false)
            {
                Console.WriteLine("Neispravan odabir akcije u menu-u, molimo ponovite unos.");
                return FetchUsersInputFromMenu();
            }

            return menuInput;
        }

        static void DisplayMenu()
        {
            Console.WriteLine("Glavni menu:");
            Console.WriteLine();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Dodaj novi event");
            Console.WriteLine("2 - Izbriši postojeći event");
            Console.WriteLine("3 - Uredi postojeći event");
            Console.WriteLine("4 - Prijavi osobu na event");
            Console.WriteLine("5 - Odjavi/ukloni prijavljenu osobu sa eventa");
            Console.WriteLine("6 - Pregledaj event (podmenu za detaljniji odabir pregleda)");
            Console.WriteLine("7 - Izađi iz aplikacije");
        }
    }
}
