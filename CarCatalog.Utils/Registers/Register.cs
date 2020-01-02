using AutoMapper;
using CarCatalog.Database;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Interfaces;
using CarCatalog.Service.Repositories.Models;
using CarCatalog.Utils.Registers.Profiles;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CarCatalog.Utils.Registers
{
    public static class Register
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<CarRepository>()
                .AddScoped<CatalogRepository>()
                .AddScoped<EngineRepository>()
                .AddScoped<UserRepository>()
                .AddScoped<CategoryRepository>();
           

            return services;
        }

        public static IMvcBuilder RegisterValidators(this IMvcBuilder mvcBuilder)
        {
            mvcBuilder
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CategoryRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CatalogRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<CarRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<EngineRequestValidator>();
                    fv.RegisterValidatorsFromAssemblyContaining<UserRequestValidator>();

                });

            return mvcBuilder;
        }

        #region Automapper
        public static IServiceCollection RegisterAutomapper(this IServiceCollection services)
        {
            var mappingConf = new MapperConfiguration(mc =>
            {
                mc.AddProfile<UserMessageProfile>();
                mc.AddProfile<CatalogMessageProfile>();
                mc.AddProfile<CategoryMessageProfile>();
                mc.AddProfile<EngineMessageProfile>();
                mc.AddProfile<CarMessageProfile>();
            });
            mappingConf.AssertConfigurationIsValid();
            IMapper mapper = mappingConf.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
        #endregion
    }
}
