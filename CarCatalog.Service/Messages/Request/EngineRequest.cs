using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Base;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CarCatalog.Service.Messages.Request
{
    public class EngineRequest : BusinessObject
    {
        public int Code { get; set; }
        public float Capacity { get; set; }
        public int HorsePower { get; set; }
        public int KiloWat { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EngineFuel Fuel { get; set; }
        public int AmountCylinders { get; set; }
        public bool Turbo { get; set; }
    }

    public class CreateEngineRequestValidator : BusinessObjectValidator<EngineRequest>
    {
        public CreateEngineRequestValidator()
        {
            RuleFor(c => c.Code).NotNull();
            RuleFor(c => c.HorsePower).NotEmpty();
            RuleFor(c => c.KiloWat).NotEmpty();
            RuleFor(c => c.Fuel).NotEmpty();
            RuleFor(c => c.Turbo).NotEmpty();
            RuleFor(c => c.AmountCylinders).NotEmpty();
        }
    }
}
