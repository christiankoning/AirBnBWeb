using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirbnbWeb.Model;

namespace AirbnbWeb.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext (DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Landlord> Landlords { get; set; }

        public DbSet<Reservation> Reservations { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
