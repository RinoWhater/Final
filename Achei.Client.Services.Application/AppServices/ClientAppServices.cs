using Achei.Client.Services.Application.Interfaces;
using Achei.Client.Services.Application.Mappers;
using Achei.Client.Services.Application.ViewModels;
using Achei.Client.Services.Domain.Entities;
using Achei.Client.Services.Domain2.Entities;
using Achei.Client.Services.Domain2.Interfaces.Service;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Achei.Client.Services.Application.AppServices {
    public class ClientAppServices : IClientAppServices {
        public string Message { get; private set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        private readonly IClientServices _clientServices;

        public ClientAppServices(IClientServices clientServices) {
            _clientServices = clientServices;
        }

        public async Task<ClientViewModel> GetClient(int clientID) { 
            ClientEntity client = await _clientServices.GetClient(clientID);
            ProcessResult<ClientEntity>(client);
            return Mapper.Map<ClientViewModel>(client);
        }

        public async Task<AddressViewModel> GetAddress(int addressID) {
            AddressEntity Address = new AddressEntity();
            Address = await _clientServices.GetAddress(addressID);
            ProcessResult<AddressEntity>(Address);
            return Mapper.Map<AddressViewModel>(Address);
        }
         
        public async Task<ClientViewModel> CreateClient(ClientViewModel client) { 
            ClientEntity clientDetail = Mapper.Map<ClientEntity>(client);
            AddressEntity Address = await _clientServices.GetAddress(client.AddressID ?? 0);
            if (Address == null) {
                ProcessResult(false, HttpStatusCode.BadRequest, "Endereço inválido!");
            }
            clientDetail.Address = Address;

            //clientDetail.Address.City = await _clientServices.GetCity(client.CityID ?? 0);
            //clientDetail.Address.City.State = await _clientServices.GetState(client.StateID ?? 0);
            //clientDetail.Address.City.State.Country = await _clientServices.GetCountry(client.CountryID ?? 0); 

            ClientEntity clientResult = await _clientServices.CreateClient(clientDetail);
            
            ProcessResult<ClientEntity>(clientResult);
            return Mapper.Map<ClientViewModel>(clientResult);
        }
        

        public async Task<ClientViewModel> UpdateClient(ClientViewModel client) { 
            ClientEntity clientResult = await _clientServices.UpdateClient(Mapper.Map<ClientEntity>(client));
            ProcessResult<ClientEntity>(clientResult);
            return Mapper.Map<ClientViewModel>(clientResult);
        }

        
        public async Task<ClientViewModel> Login(LoginViewModel login) {  
            ClientEntity clientResult = await _clientServices.Login(login.Email, login.Password);
            ProcessResult<ClientEntity>(clientResult);
            return Mapper.Map<ClientViewModel>(clientResult);
        }

        private void ProcessResult(bool success, HttpStatusCode statusCode, string message) { 
            Success = success;
            StatusCode = statusCode;
            Message = message; 
        }

        private void ProcessResult<T>(T entityList) {
            if (entityList != null) {
                Success = true;
                StatusCode = HttpStatusCode.OK;
            }
            else {
                Success = false;
                StatusCode = HttpStatusCode.Gone;
                Message = "Nenhum registro encontrado.";
            }
        }

        private void ProcessResult<T>(IEnumerable<T> entityList) {
            if (entityList.Any()) {
                Success = true;
                StatusCode = HttpStatusCode.OK;
            }
            else {
                Success = false;
                StatusCode = HttpStatusCode.Gone;
                Message = "Nenhum registro encontrado.";
            }
        }
    }
}
