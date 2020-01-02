using AutoMapper;
using CarCatalog.Database.Base;
using CarCatalog.Service.Messages.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Utils.Registers.Profiles
{
    public class BaseMessageProfile : Profile
    {
        public BaseMessageProfile() : base()
        {
            CreateMap<BusinessObject, Entity>()
                .ForMember(e => e.CreatedDateEntity, b => b.Ignore())
                .ForMember(e => e.IsDeleted, b => b.Ignore())
                .ForMember(e => e.UpdateDateEntity, b => b.Ignore())
                .ReverseMap();
        }
    }
}
