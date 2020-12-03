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

            return confirmationInput == 1;
        }

        public static bool IsActionRepeatConfirmed()
        {
            var isConfirmationDone = false;
            var confirmationInput = 0;

            Console.WriteLine();

            while (isConfirmationDone == false)
            {
                Console.WriteLine("Želite ponoviti prethodnu radnju?");
                Console.WriteLine("0 - Ponovi");
                Console.WriteLine("1 - Odustani");

                isConfirmationDone = int.TryParse(Console.ReadLine(), out confirmationInput);

                if (isConfirmationDone == false || (confirmationInput != 0 && confirmationInput != 1))
                {
                    Console.WriteLine("Neispravan unos, ponovite!");
                    isConfirmationDone = false;
                }
            }

            return confirmationInput == 1;
        }
    }
}
