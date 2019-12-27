using AutoMapper;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCatalog.Utils.Registers.Profiles
{
    public class UserMessageProfile : Profile
    {
        public UserMessageProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserRequest, User>()
                .ForMember(c => c.Catalogs, r => r.Ignore());
        }
    }
}
