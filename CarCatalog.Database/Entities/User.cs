using CarCatalog.Database.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Avatar { get; set; }
        public virtual ICollection<Catalog> Catalogs { get; set; }
    }
}
