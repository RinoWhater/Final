using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achei.Client.Services.Application.Configurations;
using Achei.Client.Services.Application.Interfaces;
using Achei.Client.Services.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using System.Net;    

namespace Achei.Client.Services.API.Controllers
{ 
    public class ClientController : ControllerBase
    {

        private readonly IClientAppServices _clientAppServices;
        private readonly AppConfiguration appConfiguration;
        private IMemoryCache _cache;    

        public ClientController(IClientAppServices clientAppServices, IOptions<AppConfiguration> options, IMemoryCache memoryCache) {
            _cache = memoryCache;
            _clientAppServices = clientAppServices;
            appConfiguration = options.Value;
        }
         
        //[HttpGet] 
        //[Route("Get/{clientID}")]                  
        //public async Task<ActionResult<ClientViewModel>> Get(int clientID) {
        //    string cachekeyName = string.Format("Get{0}", clientID);
        //    ClientViewModel client = new ClientViewModel();

        //    try {
        //        if (!_cache.TryGetValue(cachekeyName, out client)) {
        //            client = await _clientAppServices.GetClient(clientID);
        //            var cacheEntryOptions = new MemoryCacheEntryOptions()
        //           .SetSlidingExpiration(TimeSpan.FromSeconds(appConfiguration.ExpireTimeCacheSecondsDefault));
        //            _cache.Set(cachekeyName, client, cacheEntryOptions);
        //        }
        //        else {
        //            _clientAppServices.Success = true;
        //            _clientAppServices.StatusCode = HttpStatusCode.OK;
        //        }
        //    }
        //    catch (Exception ex) { 
        //        return new ObjectResult(new ObjectResultViewModel(false, client, HttpStatusCode.InternalServerError, ex.Message));
        //    }
             
        //    return new ObjectResult(new ObjectResultViewModel(_clientAppServices.Success, client, _clientAppServices.StatusCode, _clientAppServices.Message));
        //}

        [HttpGet]
        [Route("Get/Address/{AddressID}")]
        public async Task<ActionResult<ClientViewModel>> GetAddress(int AddressID)
        {
            string cachekeyName = string.Format("GetAddress{0}", AddressID);
            AddressViewModel address = new AddressViewModel();

            try
            {
                if (!_cache.TryGetValue(cachekeyName, out address))
                {
                    address = await _clientAppServices.GetAddress(AddressID);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(appConfiguration.ExpireTimeCacheSecondsDefault));
                    _cache.Set(cachekeyName, address, cacheEntryOptions);
                }
                else
                {
                    _clientAppServices.Success = true;
                    _clientAppServices.StatusCode = HttpStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                return new ObjectResult(new ObjectResultViewModel(false, null, HttpStatusCode.InternalServerError, ex.Message));
            }

            return new ObjectResult(new ObjectResultViewModel(_clientAppServices.Success, address, _clientAppServices.StatusCode, _clientAppServices.Message));
        }

        [HttpPost]
        [Route("Post")]
        public async Task<ActionResult<ClientViewModel>> Post([FromBody]ClientViewModel createClient) {
            ClientViewModel client = new ClientViewModel();
            try {

                if (!ModelState.IsValid) {
                    return new ObjectResult(new ObjectResultViewModel(false, null, HttpStatusCode.InternalServerError, ModelState.Values.SelectMany(e => e.Errors).FirstOrDefault()?.ErrorMessage));
                }

                client = await _clientAppServices.CreateClient(createClient);
            }
            catch (Exception ex) {
                return new ObjectResult(new ObjectResultViewModel(false, null, HttpStatusCode.InternalServerError, ex.Message));
            }
            
            return new ObjectResult(new ObjectResultViewModel(_clientAppServices.Success, client, _clientAppServices.StatusCode, _clientAppServices.Message));
        }

        [HttpPut]
        [Route("Put")]
        public async Task<ActionResult<ClientViewModel>> Put([FromBody] ClientViewModel updateClient) {
            ClientViewModel client = new ClientViewModel();
            try {
                client = await _clientAppServices.UpdateClient(updateClient);
            } catch (Exception ex) {
                return new ObjectResult(new ObjectResultViewModel(false, null, HttpStatusCode.InternalServerError, ex.Message));
            }
            return new ObjectResult(new ObjectResultViewModel(_clientAppServices.Success, client, _clientAppServices.StatusCode, _clientAppServices.Message));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<ClientViewModel>> Login([FromBody]LoginViewModel login) {
            ClientViewModel client = new ClientViewModel();
            try {

                if (!ModelState.IsValid) { 
                    return new ObjectResult(new ObjectResultViewModel(false, null, HttpStatusCode.InternalServerError, ModelState.Values.SelectMany(e => e.Errors).FirstOrDefault()?.ErrorMessage));
                }

                client = await _clientAppServices.Login(login);
            }
            catch (Exception ex) {
                return new ObjectResult(new ObjectResultViewModel(false, null, HttpStatusCode.InternalServerError, ex.Message));
            } 
            return new ObjectResult(new ObjectResultViewModel(_clientAppServices.Success, client, client == null? HttpStatusCode.NoContent : _clientAppServices.StatusCode, _clientAppServices.Message));
        }

    }
}
