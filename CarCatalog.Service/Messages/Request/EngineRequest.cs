using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Base;
using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CarCatalog.Service.Messages.Request
{
    public class EngineRequest : BusinessObject
    {
        public string Code { get; set; }
        public float Capacity { get; set; }
        public int HorsePower { get; set; }
        public int KiloWat { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EngineFuel Fuel { get; set; }
        public int AmountCylinders { get; set; }
        public bool Turbo { get; set; }
    }

    public class EngineRequestValidator : BusinessObjectValidator<EngineRequest>
    {
        public EngineRequestValidator()
        {
            RuleFor(c => c.Code).NotNull();
            RuleFor(c => c.HorsePower).NotEmpty();
            RuleFor(c => c.KiloWat).NotEmpty();
            RuleFor(c => c.Fuel).IsInEnum();
            RuleFor(c => c.Turbo).NotEmpty();
            RuleFor(c => c.AmountCylinders).NotEmpty();
        }
    }
}
