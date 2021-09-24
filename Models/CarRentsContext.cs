using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarRents.Models
{
    public class CarRentsContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarRent> CarRents { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Renter> Renters{ get; set; }
        public CarRentsContext(DbContextOptions<CarRentsContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
