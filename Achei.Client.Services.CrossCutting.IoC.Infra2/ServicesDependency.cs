using Achei.Client.Services.Application.AppServices;
using Achei.Client.Services.Application.Configurations;
using Achei.Client.Services.Application.Interfaces;
using Achei.Client.Services.Application.Mappers;
using Achei.Client.Services.Application.ViewModels;
using Achei.Client.Services.Data.Infra.Context;
using Achei.Client.Services.Domain2.Entities;
using Achei.Client.Services.Domain2.Interfaces.Service;
using Achei.Client.Services.Domain2.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Achei.Client.Services.Domain.Interfaces.Repository;
using Achei.Client.Services.Data.Infra.Repository;
using Achei.Client.Services.Domain.Entities;

namespace Achei.Client.Services.CrossCutting.IoC.Infra2 {
    public class ServicesDependency {

        public static void AddServicesDependency(IServiceCollection services, IConfiguration configuration) {

            AppConfiguration appConfiguration = configuration.GetSection(nameof(AppConfiguration)).Get<AppConfiguration>();

            #region Injeção de Dependência

            //// App
            services.AddScoped<IClientAppServices, ClientAppServices>();

            //// Domain
            services.AddScoped<IClientServices, ClientServices>();

            //// Infra
            services.AddScoped<ClientContext>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddDbContext<ClientContext>(s => s.UseSqlServer(configuration.GetConnectionString("Client"), builder => builder.UseRowNumberForPaging()));

            #endregion

            #region Mapeamento

            Mapper.CreateMap<ClientEntity, ClientViewModel>()
                .ForMember(dest => dest.Street, src => src.Address.Street)
                .ForMember(dest => dest.Number, src => src.Address.Number)
                .ForMember(dest => dest.Neighborhood, src => src.Address.Neighborhood)
                .ForMember(dest => dest.ZipCode, src => src.Address.ZipCode)
                .ForMember(dest => dest.Complement, src => src.Address.Complement)
                .ForMember(dest => dest.City, src => src.Address.City.Name)
                .ForMember(dest => dest.State, src => src.Address.City.State.Name)
                .ForMember(dest => dest.Country, src => src.Address.City.State.Country.Name);
            Mapper.CreateMap<ClientViewModel,ClientEntity>();
            Mapper.CreateMap<AddressEntity, AddressViewModel>() 
                .ForMember(dest => dest.City, src => src.City.Name)
                .ForMember(dest => dest.State, src => src.City.State.Name)
                .ForMember(dest => dest.Country, src => src.City.State.Country.Name);
             
            Mapper.Initialize();

            #endregion
        }
    }
}
