using Achei.Client.Services.Domain.Entities;
using Achei.Client.Services.Domain.Interfaces.Repository;
using Achei.Client.Services.Domain2.Entities;
using Achei.Client.Services.Domain2.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Achei.Client.Services.Domain2.Services {
    public class ClientServices : IClientServices {

        private readonly IClientRepository _clientRepository;

        public ClientServices(IClientRepository clientRepository) {
            _clientRepository = clientRepository;
        }

        public async Task<ClientEntity> GetClient(int clientID) {
            return await _clientRepository.GetClient(clientID); ;
        }

        public async Task<AddressEntity> GetAddress(int addressID) { 
            return await _clientRepository.GetAddress(addressID); 
        }
         
        public async Task<ClientEntity> CreateClient(ClientEntity client) { 
            client.Status = true;
            client.CreationDate = DateTime.Now;  
            return await _clientRepository.CreateClient(client);
        }

        public async Task<ClientEntity> UpdateClient(ClientEntity client) { 
            return await _clientRepository.UpdateClient(client);
        }
        
        public async Task<ClientEntity> Login(string email, string password) {
            return await _clientRepository.Login(email, password);
        }

        public async Task<CityEntity> GetCity(int CityID) {
            return await _clientRepository.GetCity(CityID);
        }

        public async Task<StateEntity> GetState(int StateID) {
            return await _clientRepository.GetState(StateID);
        }

        public async Task<CountryEntity> GetCountry(int CountryID) {
            return await _clientRepository.GetCountry(CountryID);
        }
    }
}
