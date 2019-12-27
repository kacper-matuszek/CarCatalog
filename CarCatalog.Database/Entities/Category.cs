using CarCatalog.Database.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public string PictureName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
