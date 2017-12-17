using gowa.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gowa.DAL
{
    public class GarageContext : DbContext
    {
        public GarageContext() : base ("GarageContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}