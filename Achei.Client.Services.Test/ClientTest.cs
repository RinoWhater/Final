using Achei.Client.Services.Application.Mappers;
using Achei.Client.Services.Application.ViewModels;
using Achei.Client.Services.Data.Infra.Context;
using Achei.Client.Services.Domain.Entities;
using Achei.Client.Services.Domain2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Achei.Client.Services.Test {
    public class ClientTest {
         
        [Fact]
        public void TestMapperAddressEntityToAddressViewModel() {
            string expectedValue = "Avenida Paulista";
            string actualValue = "";

            AddressEntity address = new AddressEntity() { Street = expectedValue };
            AddressViewModel addressViewModel = Mapper.Map<AddressViewModel>(address);
            
            actualValue = addressViewModel.Street;

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void TestMapperClientEntityToClientViewModel() {
            string expectedValue = "teste@teste.com.br";
            string actualValue = "";

            ClientEntity client = new ClientEntity() { Email = expectedValue };
            ClientViewModel clientViewModel = Mapper.Map<ClientViewModel>(client);
            actualValue = clientViewModel.Email;

            Assert.Equal(expectedValue, actualValue);
        }

        [Fact]
        public void TestMapperClientViewModelToClientEntity() {
            InicializaMapper();
            string expectedValue = "teste@teste.com.br";
            string actualValue = "";

            ClientViewModel clientViewModel = new ClientViewModel() { Email = expectedValue };
            ClientEntity client = Mapper.Map<ClientEntity>(clientViewModel);
            actualValue = client.Email;
            //actualValue = client.Phone;

            Assert.Equal(expectedValue, actualValue);
        }

        private void InicializaMapper() {

            Mapper.CreateMap<ClientEntity, ClientViewModel>()
                .ForMember(dest => dest.Street, src => src.Address.Street)
                .ForMember(dest => dest.Number, src => src.Address.Number)
                .ForMember(dest => dest.Neighborhood, src => src.Address.Neighborhood)
                .ForMember(dest => dest.ZipCode, src => src.Address.ZipCode)
                .ForMember(dest => dest.Complement, src => src.Address.Complement)
                .ForMember(dest => dest.City, src => src.Address.City.Name)
                .ForMember(dest => dest.State, src => src.Address.City.State.Name)
                .ForMember(dest => dest.Country, src => src.Address.City.State.Country.Name);
            Mapper.CreateMap<ClientViewModel, ClientEntity>();
            Mapper.CreateMap<AddressEntity, AddressViewModel>()
                .ForMember(dest => dest.City, src => src.City.Name)
                .ForMember(dest => dest.State, src => src.City.State.Name)
                .ForMember(dest => dest.Country, src => src.City.State.Country.Name);

            Mapper.Initialize(); 
        }
    }
}
