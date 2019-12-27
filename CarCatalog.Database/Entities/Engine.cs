using CarCatalog.Database.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Entities
{
    public class Engine : Entity
    {
        public int Code { get; set; }
        public float Capacity { get; set; }
        public int HorsePower { get; set; }
        public int KiloWat { get; set; }
        public EngineFuel Fuel { get; set; }
        public int AmountCylinders { get; set; }
        public bool Turbo { get; set; }
        public virtual ICollection<Car> Cars { get; set; }

    }

    public enum EngineFuel
    {
        Petrol,
        Diesel,
        Electrical,
        Hybrid
    }
}
