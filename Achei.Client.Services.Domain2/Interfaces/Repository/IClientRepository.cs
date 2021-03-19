using Achei.Client.Services.Domain.Entities;
using Achei.Client.Services.Domain2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Achei.Client.Services.Domain.Interfaces.Repository {
    public interface IClientRepository{

        Task<ClientEntity> GetClient(int ClientID);
        Task<AddressEntity> GetAddress(int AddressID);
        Task<CityEntity> GetCity(int CityID);
        Task<StateEntity> GetState(int StateID);
        Task<CountryEntity> GetCountry(int CountryID);
        Task<ClientEntity> CreateClient(ClientEntity Client);
        Task<ClientEntity> UpdateClient(ClientEntity Client);
        Task<ClientEntity> Login(string email, string password);
    }
}
