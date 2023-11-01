using CarServiceBL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceEF.Repositories
{
    public class AppDbContext:IdentityDbContext
    {
        public IEnumerable prodects;

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) {  }

        public DbSet<Service> Services { get; set; }
        public DbSet<Technician> Technicians  { get; set; }
        
        public DbSet<Booking> Bookings  { get; set; }

        public DbSet<Comment> Comments  { get; set; }
        public DbSet<Prodect> Prodecet { get; set; }

    }
}
