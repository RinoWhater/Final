using Achei.Client.Services.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Achei.Client.Services.Application.Interfaces {
    public interface IClientAppServices {

        string Message { get; }
        bool Success { get; set; }
        HttpStatusCode StatusCode { get; set; }

       Task<ClientViewModel> GetClient(int clientID);
       Task<AddressViewModel> GetAddress(int addressID);
       Task<ClientViewModel> CreateClient(ClientViewModel client);
       Task<ClientViewModel> UpdateClient(ClientViewModel client);
       Task<ClientViewModel> Login(LoginViewModel login);
    }
}
