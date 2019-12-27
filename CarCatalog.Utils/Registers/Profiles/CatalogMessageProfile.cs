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
                .ForMember(c => c.User, r => r.Ignore())
                .ForMember(c => c.Cars, r => r.Ignore());
        }
    }
}
