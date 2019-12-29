using AutoMapper;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Utils.Registers.Profiles
{
    public class CatalogMessageProfile : Profile
    {
        public CatalogMessageProfile()
        {
            CreateMap<Catalog, CatalogResponse>();
            CreateMap<CatalogRequest, Catalog>()
                .ForMember(e => e.Id, b => b.Condition(
                    (src, dest, srcValue, destValue, c) => !c.Options.Items.ContainsKey("Create"))); ;
        }
    }
}
