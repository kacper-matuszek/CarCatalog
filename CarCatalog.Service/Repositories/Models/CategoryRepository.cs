using AutoMapper;
using CarCatalog.Database;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Models
{
    public class CategoryRepository : BusinessRepository<Category, CarCatalogContext, CategoryResponse, CategoryRequest>
    {
        public CategoryRepository(CarCatalogContext context) : base(context)
        {
        }
    }
}
