using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
