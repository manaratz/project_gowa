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
            var brands = new List<Brand>
            {
                new Brand{Name="Renault"},
                new Brand{Name="Mercedes-Benz"},
                new Brand{Name="Volkswagen"},
                new Brand{Name="Alfa Roméo"},
                new Brand{Name="Fiat"},
                new Brand{Name="Ford"},
                new Brand{Name="Peugeot"},
                new Brand{Name="Citroên"},
                new Brand{Name="B.M.W."},
                new Brand{Name="Honda"},
                new Brand{Name="Toyota"},
                new Brand{Name="Audi"}
            };
            brands.ForEach(b => context.Brands.Add(b));
            context.SaveChanges();
            var models = new List<Model>
            {
                new Model{Name="Clio",BrandID=1},
                new Model{Name="A-Class",BrandID=2},
                new Model{Name="Golf",BrandID=3},
                new Model{Name="Giulia",BrandID=4},
                new Model{Name="500",BrandID=5},
                new Model{Name="Focus",BrandID=6},
                new Model{Name="308",BrandID=7},
                new Model{Name="C3",BrandID=8},
                new Model{Name="X5",BrandID=9},
                new Model{Name="Civic",BrandID=10},
                new Model{Name="Aygo",BrandID=11},
                new Model{Name="RS3",BrandID=12}
            };
            models.ForEach(m => context.Models.Add(m));
            context.SaveChanges();

            var workshops = new List<Workshop>
            {
                new Workshop{Name="Park it",Location="Paris"},
                new Workshop{Name="Car Wars",Location="Marseille"},
                new Workshop{Name="Kammthaar",Location="Strasbrourg"},
                new Workshop{Name="Carputer",Location="Toulouse"},
                new Workshop{Name="Cardealogist",Location="Lyon"}
            };
            workshops.ForEach(w => context.Workshops.Add(w));
            context.SaveChanges();

            var cars = new List<Car>
            {
                new Car{BrandID=1, HorsePower=90, ModelID=1,WorkShopID=1}
            };
            cars.ForEach(c => context.Cars.Add(c));
            context.SaveChanges();
        }
    }
}