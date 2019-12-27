using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Service.Messages.Request
{
    public class CarRequest : BusinessObject
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
        public CatalogRequest Catalog { get; set; }
        public CategoryRequest Category { get; set; }
        public EngineRequest Engine { get; set; }
    }

    public class CreateCarRequestValidator : BusinessObjectValidator<CarRequest>
    {
        public CreateCarRequestValidator()
        {
            RuleFor(c => c.VIN).NotEmpty();
            RuleFor(c => c.Manufacturer).NotEmpty();
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.Engine).NotNull();
            RuleFor(c => c.Catalog).NotNull();
            RuleFor(c => c.Category).NotNull();
        }
    }
}
