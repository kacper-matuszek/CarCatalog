using System;
using System.Collections.Generic;
using System.Text;
using CarCatalog.Database;
using CarCatalog.Database.Base;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Service.Repositories.Base
{
    public class DatabaseRepository<T> : RepositoryBase<T> where T : Entity
    {
        public DatabaseRepository(CarCatalogContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
