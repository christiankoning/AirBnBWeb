using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AirbnbWeb.Model
{
    public class House
    {
        public int Id { get; set; }
        public string HouseName { get; set; }
        public string HouseDescription { get; set; }
        public Landlord Landlord { get; set; }
        public HouseTypes HouseType { get; set; }
        public int MaxPerson { get; set; }
        public float Price { get; set; }
        public int BedroomTotal { get; set; }
        public int BedTotal { get; set; }
        public int BathroomTotal { get; set; }
        public bool SmokingAllowed { get; set; }
        public string Streetname { get; set; }
        public string HouseNumber { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public enum HouseTypes
        {
            Bungalow,
            Apartment,
            Castle,
            House,
            Hotel
        }
    }

}
