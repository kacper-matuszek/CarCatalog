using CarCatalog.Database.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Entities
{
    public class Catalog : Entity
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
