using System;
using System.Collections.Generic;
using System.Text;

namespace EventAttendanceApp.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Pošto je sav kod na eng., oib sam odlučio nazvat pin -> Personal Id Number
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }
    }
}
