using AutoMapper;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Utils.Registers.Profiles
{
    public class CategoryMessageProfile : Profile
    {
        public CategoryMessageProfile() : base()
        {
            CreateMap<Category, CategoryResponse>()
                .ReverseMap();

            CreateMap<CategoryRequest, Category>()
                .ForMember(e => e.IsDeleted, s => s.Ignore())
                .ForMember(e => e.CreatedDateEntity, s => s.Ignore())
                .ForMember(e => e.UpdateDateEntity, s => s.Ignore())
                .ForMember(c => c.Cars, r => r.Ignore())
                .ForMember(e => e.Id, b => b.Condition(
                    (src, dest, srcValue, destValue, c) => !c.Options.Items.ContainsKey("Create")))
                .ReverseMap(); 
        }
    }
}
