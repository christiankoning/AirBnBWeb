using AirbnbWeb.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirbnbWeb.ViewModel
{
    public class HouseViewModel
    {
        public House House { get; set; }
        public SelectList AllHouses { get; set; }
        public Reservation Reservation { get; set; }
        public Customer Customer { get; set; }
    }
}
