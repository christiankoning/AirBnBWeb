using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace AirbnbWeb.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public int HouseId { get; set; }
        public virtual House House { get; set; }
        public virtual Customer Customer { get; set; }

        public float Price { get; set; }
    }

}
