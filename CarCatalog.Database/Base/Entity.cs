using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Database.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateEntity { get; set; }
        public DateTime UpdateDateEntity { get; set; }
        public bool IsDeleted { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedDateEntity = DateTime.Now;
            UpdateDateEntity = DateTime.Now;
            IsDeleted = false;
        }
    }
}
