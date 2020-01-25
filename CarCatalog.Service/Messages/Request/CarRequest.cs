using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CarCatalog.Service.Messages.Request
{
    public class CarRequest : BusinessObject
    {
        public string VIN { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public DriveType DriveType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public GearBox GearBox { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Database.Entities.Type Type { get; set; }
        public int AmountDoors { get; set; }
        public int AmountSeats { get; set; }
        public string OriginCountry { get; set; }
        public string PictureName { get; set; }
        public Guid? CatalogId { get; set; }
        public Guid CategoryId { get; set; }
        public EngineRequest Engine { get; set; }
    }

    public class CarRequestValidator : BusinessObjectValidator<CarRequest>
    {
        public CarRequestValidator()
        {
            RuleFor(c => c.VIN).NotEmpty();
            RuleFor(c => c.Manufacturer).NotEmpty();
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.Engine).SetValidator(new EngineRequestValidator());
            RuleFor(c => c.CategoryId).NotNull().NotEmpty();
            RuleFor(c => c.GearBox).IsInEnum();
            RuleFor(c => c.DriveType).IsInEnum();
            RuleFor(c => c.Type).IsInEnum();
        }
    }
}
