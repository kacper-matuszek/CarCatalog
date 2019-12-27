using CarCatalog.Database.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Entities
{
    public class Car : Entity
    {
        public Guid EngineId { get; set; }
        public Guid CategoryId { get; set; }
        public Guid CatalogId { get; set; }
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public DriveType DriveType { get; set; }
        public GearBox GearBox { get; set; } 
        public Type Type { get; set; }
        public int AmountDoors { get; set; }
        public int AmountSeats { get; set; }
        public string OriginCountry { get; set; }
        public string PictureName { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual Category Category { get; set; }
        public virtual Catalog Catalog { get; set; }
    }

    public enum DriveType
    {
        FrontWheel,
        RearWheel,
        AllWheel,
        FourWheel
    }

    public enum GearBox
    {
        Manual,
        Automatic,
        SemiAutomatic,
        Stepless
    }

    public enum Type
    {
        Hatchback,
        Sedan,
        Combi,
        SUV,
        Cabriolet,
        Coupe
    }
}
