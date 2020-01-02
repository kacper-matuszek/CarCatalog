using AutoMapper;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Utils.Registers.Profiles
{
    public class CarMessageProfile : Profile
    {
        public CarMessageProfile()
        {
            CreateMap<Car, CarResponse>();
            CreateMap<CarRequest, Car>()
                .ForMember(e => e.Id, b => b.Condition(
                    (src, dest, srcValue, destValue, c) => !c.Options.Items.ContainsKey("Create")))
                .ForMember(e => e.Catalog, c => c.Ignore())
                .ForMember(e => e.Category, c => c.Ignore())
                .ForMember(e => e.CatalogId, c => c.MapFrom(b => b.Catalog))
                .ForMember(e => e.CategoryId, c => c.MapFrom(b => b.Category))
                .ForMember(e => e.EngineId, c => c.Ignore())
                .ForMember(e => e.Engine, c => c.MapFrom(b => b.Engine))
                .ForMember(e => e.IsDeleted, s => s.Ignore())
                .ForMember(e => e.CreatedDateEntity, s => s.Ignore())
                .ForMember(e => e.UpdateDateEntity, s => s.Ignore());
        }
    }
}
