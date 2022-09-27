using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AirbnbWeb.Model
{
    public class Customer
    {
        public int ReservationId { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Phonenumber { get; set; }
        public string Streetname { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
