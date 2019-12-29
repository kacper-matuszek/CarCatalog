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
                .AddScoped<RepositoryBase<Car>, DatabaseRepository<Car>>()
                .AddScoped<RepositoryBase<Catalog>, DatabaseRepository<Catalog>>()
                .AddScoped<RepositoryBase<Category>, DatabaseRepository<Category>>()
                .AddScoped<RepositoryBase<Engine>, DatabaseRepository<Engine>>()
                .AddScoped<RepositoryBase<User>, DatabaseRepository<User>>()
                .AddScoped<BusinessRepository<Car, CarResponse, CarRequest>, CarRepository>()
                .AddScoped<BusinessRepository<Catalog, CatalogResponse, CatalogRequest>, CatalogRepository>()
                .AddScoped<BusinessRepository<Category, CategoryResponse, CategoryRequest>, CategoryRepository>()
                .AddScoped<BusinessRepository<Engine, EngineResponse, EngineRequest>, EngineRepository>()
                .AddScoped<BusinessRepository<User, UserResponse, UserRequest>, UserRepository>();

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
                mc.AddProfile<CarMessageProfile>();
                mc.AddProfile<CatalogMessageProfile>();
                mc.AddProfile<CategoryMessageProfile>();
                mc.AddProfile<EngineMessageProfile>();
                mc.AddProfile<UserMessageProfile>();
            });

            IMapper mapper = mappingConf.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
        #endregion
    }
}
