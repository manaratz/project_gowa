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
            var models = new List<Model>
            {
                new Model{Name="Renault - Clio"},
                new Model{Name="Mercedes-Benz - A Class"},
                new Model{Name="Volkswagen - Golf"},
                new Model{Name="Alfa Roméo - Giulia"},
                new Model{Name="Fiat - 500"},
                new Model{Name="Ford - Focus"},
                new Model{Name="Peugeot - 308"},
                new Model{Name="Citroën - C3"},
                new Model{Name="B.M.W. - X5"},
                new Model{Name="Honda - Civic"},
                new Model{Name="Toyota - Aygo"},
                new Model{Name="Audi - RS3"}
            };
            models.ForEach(m => context.Models.Add(m));
            context.SaveChanges();

            var workshops = new List<Workshop>
            {
                new Workshop{Name="Park it",Location="Paris"},
                new Workshop{Name="Car Wars",Location="Marseille"},
                new Workshop{Name="Kammthaar",Location="Strabrourg"},
                new Workshop{Name="Carputer",Location="Toulouse"},
                new Workshop{Name="Cardealogist",Location="Lyon"}
            };
            workshops.ForEach(w => context.Workshops.Add(w));
            context.SaveChanges();

            var cars = new List<Car>
            {
                new Car{HorsePower=90, ModelID=1,WorkShopID=1}
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();
        }
    }
}