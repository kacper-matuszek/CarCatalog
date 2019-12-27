using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Response
{
    public class CarResponse : BusinessObject
    {
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public DriveType DriveType { get; set; }
        public GearBox GearBox { get; set; }
        public Database.Entities.Type Type { get; set; }
        public int AmountDoors { get; set; }
        public int AmountSeats { get; set; }
        public string OriginCountry { get; set; }
        public string PictureName { get; set; }
        public CatalogResponse Catalog { get; set; }
        public CategoryResponse Category { get; set; }
        public EngineResponse Engine { get; set; }
    }
}
