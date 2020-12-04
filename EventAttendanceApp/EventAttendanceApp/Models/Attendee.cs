namespace EventAttendanceApp.Models
{
    public class Attendee
    {
        public Attendee(string firstName, string lastName, string pin, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PIN = pin;
            PhoneNumber = phoneNumber;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //Pošto je sav kod na eng., oib sam odlučio nazvat pin -> Personal Id Number
        public string PIN { get; set; }
        public string PhoneNumber { get; set; }
    }
}