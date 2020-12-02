using System;

namespace EventAttendanceApp.Models
{
    public class Attendee
    {
        public Attendee(string firstName, string lastName, string pin, string phoneNumber)
        {
            if (firstName.Length <= 0)
            {
                throw new ArgumentException("Pogreška: Neispravno uneseno ime pristupnika eventu!");
            }

            if (lastName.Length <= 0)
            {
                throw new ArgumentException("Pogreška: Neispravno uneseno prezime pristupnika eventu!");
            }

            if (pin.Length <= 0)
            {
                throw new ArgumentException("Pogreška: Neispravno unesen OIB pristupnika eventu!");
            }

            if (phoneNumber.Length <= 0)
            { 
                throw new ArgumentException("Pogreška: Neispravno unesen broj mobitela pristupnika eventu!");
            }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Pošto je sav kod na eng., oib sam odlučio nazvat pin -> Personal Id Number
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }
    }
}
