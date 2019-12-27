using CarCatalog.Service.Messages.Base;
using CarCatalog.Database.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CarCatalog.Service.Messages.Response
{
    public class EngineResponse : BusinessObject
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
}
