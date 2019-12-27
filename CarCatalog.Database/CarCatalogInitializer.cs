using Bogus;
using CarCatalog.Database.Base;
using CarCatalog.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarCatalog.Database
{
    public static class CarCatalogInitializer
    {
        private static Dictionary<int, Engine> _engines = new Dictionary<int, Engine>();
        private static Dictionary<int, Category> _categories = new Dictionary<int, Category>();
        private static Dictionary<int, User> _users = new Dictionary<int, User>();
        private static Dictionary<int, Catalog> _catalogs = new Dictionary<int, Catalog>();
        private readonly static Faker _faker = new Faker();

        public static Car[] SeedCars()
        {
            var cars = new Faker<Car>()
                .RuleFor(c => c.Manufacturer, s => s.Vehicle.Manufacturer())
                .RuleFor(c => c.Model, s => s.Vehicle.Model())
                .RuleFor(c => c.Color, s => s.Commerce.Color())
                .RuleFor(c => c.Type, s => s.PickRandom<Entities.Type>())
                .RuleFor(c => c.DriveType, s => s.PickRandom<DriveType>())
                .RuleFor(c => c.OriginCountry, s => s.Address.Country())
                .RuleFor(c => c.AmountDoors, s => s.Random.Number(2, 5))
                .RuleFor(c => c.AmountSeats, s => s.Random.Number(2, 5))
                .RuleFor(c => c.GearBox, s => s.PickRandom<GearBox>())
                .RuleFor(c => c.Mileage, s => s.Random.Number(200000))
                .RuleFor(c => c.VIN, s => s.Vehicle.Vin())
                .Generate(20);

            cars.ForEach(c =>
            {
                c.EngineId = _engines.GetRandom().Id;
                c.CategoryId = _categories.GetRandom().Id;
                c.CatalogId = _catalogs.GetRandom().Id;
                c.PictureName = $"{c.Manufacturer}.jpg";
            });
         
            return cars.ToArray();
        } 

        public static Engine[] SeedEngines()
        {
            
            var engines = new List<Engine>
            {
                /* Petrol*/
                new Engine() { Code = 25, Capacity = 1.0f,  HorsePower = 95, KiloWat = 70,
                Turbo = true, AmountCylinders = 3, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 30, Capacity = 1.0f,  HorsePower = 116, KiloWat = 85,
                Turbo = true, AmountCylinders = 3, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 35, Capacity = 1.5f,  HorsePower = 150, KiloWat = 110,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 40, Capacity = 2.0f,  HorsePower = 200, KiloWat = 147,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Capacity = 1.4f, HorsePower = 204, KiloWat = 150,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Capacity = 2.0f,  HorsePower = 300, KiloWat = 221,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Capacity = 2.5f,  HorsePower = 400, KiloWat = 294,
                Turbo = true, AmountCylinders = 5, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 35, Capacity = 2.0f,  HorsePower = 150, KiloWat = 110,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 40, Capacity = 2.0f,  HorsePower = 190, KiloWat = 140,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 45, Capacity = 2.0f,  HorsePower = 245, KiloWat = 180,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Petrol},
                new Engine() { Capacity = 3.0f,  HorsePower = 354, KiloWat = 260,
                Turbo = true, AmountCylinders = 6, Fuel = EngineFuel.Petrol},
                new Engine() { Capacity = 2.9f,  HorsePower = 450, KiloWat = 331,
                Turbo = true, AmountCylinders = 6, Fuel = EngineFuel.Petrol},
                new Engine() { Code = 55, Capacity = 3.0f,  HorsePower = 340, KiloWat = 250,
                Turbo = true, AmountCylinders = 6, Fuel = EngineFuel.Petrol},
                /*Petrol*/

                /*Diesel*/
                new Engine() { Code = 35, Capacity = 2.0f,  HorsePower = 150, KiloWat = 110,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Diesel},
                new Engine() { Code = 40, Capacity = 2.0f,  HorsePower = 190, KiloWat = 140,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Diesel},
                new Engine() { Code = 40, Capacity = 2.0f,  HorsePower = 204, KiloWat = 150,
                Turbo = true, AmountCylinders = 4, Fuel = EngineFuel.Diesel },
                new Engine() { Capacity = 3.0f,  HorsePower = 347, KiloWat = 255,
                Turbo = true, AmountCylinders = 6, Fuel = EngineFuel.Diesel},
                new Engine() { Code = 50, Capacity = 3.0f,  HorsePower = 286, KiloWat = 210,
                Turbo = true, AmountCylinders = 6, Fuel = EngineFuel.Diesel},
                new Engine() { Code = 45, Capacity = 3.0f,  HorsePower = 231, KiloWat = 170,
                Turbo = true, AmountCylinders = 6, Fuel = EngineFuel.Diesel}
                /*Diesel*/
            };

            _engines = SeedHelper<Engine>(engines);

            return engines.ToArray();
        }

        public static Category[] SeedCategories()
        {
            var categories = new List<Category>()
            {
                new Category(){ Name = "Sport", PictureName = "Sport.jpg"},
                new Category(){ Name = "Limousine", PictureName = "Limousine.jpg"},
                new Category(){ Name = "Passenger", PictureName = "Passenger.jpg"}
            };

            _categories = SeedHelper<Category>(categories);

            return categories.ToArray();
        }

        public static User[] SeedUsers()
        {
            var users = new Faker<User>()
                .RuleFor(u => u.UserName, s => s.Internet.UserName())
                .RuleFor(u => u.Avatar, s => s.Internet.Avatar())
                .Generate(4);

            _users = SeedHelper<User>(users);

            return users.ToArray();
        }

        public static Catalog[] SeedCatalogs()
        {
            var catalogs = new Faker<Catalog>()
                .RuleFor(c => c.CreatedDate, s => s.Date.Recent())
                .RuleFor(c => c.Name, s => s.Lorem.Word())
                .Generate(2);
            catalogs.ForEach(c => c.UserId = _users[_faker.Random.Number(_users.Count()) - 1].Id);

            _catalogs = SeedHelper<Catalog>(catalogs);
            
            return catalogs.ToArray();
        }

        #region Helper Methods
        private static Dictionary<int,T> SeedHelper<T>(IList<T> list)
        {
            var result = new Dictionary<int, T>();

            foreach (var item in list)
                result.Add(list.IndexOf(item), item);

            return result;
        }
        private static T GetRandom<T>(this Dictionary<int, T> pairs) where T : Entity
        {
            return pairs[_faker.Random.Number(pairs.Count() - 1)];
        }
        #endregion
    }
}
