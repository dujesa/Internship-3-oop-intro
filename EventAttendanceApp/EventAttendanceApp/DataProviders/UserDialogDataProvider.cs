using System;

namespace EventAttendanceApp.DataProviders
{
    public static class UserDialogDataProvider
    {
        public static bool ConfirmAction()
        {
            var isConfirmationDone = false;
            var confirmationInput = 0;

            Console.WriteLine();

            while (isConfirmationDone == false)
            {
                Console.WriteLine("Unesite:");
                Console.WriteLine("0 - Odustani od akcije");
                Console.WriteLine("1 - Potvrdi akciju");

                isConfirmationDone = int.TryParse(Console.ReadLine(), out confirmationInput);

                if (isConfirmationDone == false || (confirmationInput != 0 && confirmationInput != 1))
                {
                    Console.WriteLine("Neispravan unos, ponovite!");
                    isConfirmationDone = false;
                }
            }

            Console.Clear();
            return confirmationInput == 1;
        }

        public static bool IsActionRepeatRequested()
        {
            var isConfirmationDone = false;
            var confirmationInput = 0;

            Console.WriteLine();

            while (isConfirmationDone == false)
            {
                Console.WriteLine("Želite ponoviti prethodnu radnju?");
                Console.WriteLine("0 - Odustani");
                Console.WriteLine("1 - Ponovi");

                isConfirmationDone = int.TryParse(Console.ReadLine(), out confirmationInput);

                if (isConfirmationDone == false || (confirmationInput != 0 && confirmationInput != 1))
                {
                    Console.WriteLine("Neispravan unos, ponovite!");
                    isConfirmationDone = false;
                }
            }

            return confirmationInput == 1;
        }

        public static int FetchUsersInputFromMenu()
        {
            DisplayMenu();

            if (int.TryParse(Console.ReadLine(), out var menuInput) == false)
            {
                Console.WriteLine("Neispravan odabir akcije u menu-u, molimo ponovite unos.");
                return FetchUsersInputFromMenu();
            }

            return menuInput;
        }

        public static int FetchUsersInputFromEventDetailsSubmenu()
        {
            DisplayEventsDetailsSubmenu();

            if (int.TryParse(Console.ReadLine(), out var menuInput) == false)
            {
                Console.WriteLine("Neispravan odabir akcije u menu-u, molimo ponovite unos.");
                return FetchUsersInputFromMenu();
            }

            return menuInput;
        }

        private static void DisplayEventsDetailsSubmenu()
        {
            Console.WriteLine("Podmenu za pregled eventa:");
            Console.WriteLine();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Pregledaj detalje eventa");
            Console.WriteLine("2 - Pregledaj prijavljene goste eventa");
            Console.WriteLine("3 - Detaljan pregled eventa");
            Console.WriteLine("4 - Izađi iz podmenua");
        }

        private static void DisplayMenu()
        {
            Console.WriteLine("Glavni menu:");
            Console.WriteLine();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("0 - Ispiši sve evente unutar aplikacije");
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
