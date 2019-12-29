using System;
using System.Collections.Generic;
using System.Text;
using CarCatalog.Database;
using CarCatalog.Database.Base;
using Microsoft.EntityFrameworkCore;

namespace CarCatalog.Service.Repositories.Base
{
    public class CommonRepository<T, Context> : RepositoryBase<T, Context>
        where T : Entity
        where Context : DbContext
    {
        public CommonRepository(Context repositoryContext) : base(repositoryContext)
        {
        }
    }
}
