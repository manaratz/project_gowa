using gowa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gowa.DAL
{
    public class GarageInitializer: System.Data.Entity.DropCreateDatabaseIfModelChanges<GarageContext>
    {
        protected override void Seed(GarageContext context)
        {
            var workshops = new List<Workshop>
            {
                new Workshop{Name="Park it",Location="Paris"}
            };
            workshops.ForEach(w => context.Workshops.Add(w));
            context.SaveChanges();
            var cars = new List<Car>
            {
                new Car{Brand="Renault", HorsePower=90, Model="Clio",CarWorkShopID=1}
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();
        }
    }
}