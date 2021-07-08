using Achei.Client.Services.Data.Infra.Context;
using Achei.Client.Services.Domain.Interfaces.Repository;
using Achei.Client.Services.Domain2.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;   
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Achei.Client.Services.Domain.Entities;
using System.Data.SqlClient;

namespace Achei.Client.Services.Data.Infra.Repository {
    public class ClientRepository : IClientRepository  {

        private ClientContext context;

        public ClientRepository(ClientContext context) {
            this.context = context;
        }

        public async Task<ClientEntity> GetClient(int ClientID) {  



            ClientEntity result;

            //ConsultaCliente
            
            //List<ClientEntity> teste = await context.Client.FromSql("ConsultaCliente").ToListAsync();

            //var param = new SqlParameter() {
            //    ParameterName = "@CPF",
            //    SqlDbType = System.Data.SqlDbType.VarChar,
            //    Direction = System.Data.ParameterDirection.Input,
            //    Size = 50,
            //    Value = "29366179444"
            //};

            //List <ClientEntity> tesffte = await context.Client.FromSql("consultaClientePorCPF @CPF ", param).ToListAsync();

            var pais = new SqlParameter() {
                ParameterName = "@pais",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Size = 50,
                Value = "Alemanha"
            };

            var sigla = new SqlParameter() {
                ParameterName = "@sigla",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Input,
                Size = 50,
                Value = "DE"
            };

            await context.Database.ExecuteSqlCommandAsync("EXEC InserirPais @pais, @sigla ", pais, sigla);

            result = await context.Client
                .Include(c => c.Address) 
                .FirstOrDefaultAsync(x => x.ID == ClientID);
            
            return result;
        }

        public async Task<AddressEntity> GetAddress(int AddressID) {
            AddressEntity result;
             
            result = await context.Address
                .Include(c => c.City)
                .ThenInclude(c => c.State)
                .ThenInclude(c => c.Country)
                .FirstOrDefaultAsync(x => x.ID == AddressID);

            return result;
        }
         
        public async Task<ClientEntity> CreateClient(ClientEntity client) {

            try {
                await context.Client.AddAsync(client);
                await context.SaveChangesAsync();
            }
            catch (Exception ex) { 
                throw ex;
            }
             
            return client;
        }
         
        public void Dispose() { 
            if (context != null) { 
                context.Dispose(); 
            } 
            GC.SuppressFinalize(this); 
        }

        public async Task<ClientEntity> UpdateClient(ClientEntity client) {
            await context.SaveChangesAsync(); 
            return client;
        }

        
        public async Task<ClientEntity> Login(string email, string password) {
            ClientEntity result;
            result = await context.Client
                .Include(c => c.Address)
                .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

            return result;
        }

        public async Task<CityEntity> GetCity(int CityID) {
            CityEntity result;

            result = await context.City 
                .FirstOrDefaultAsync(x => x.ID == CityID);

            return result;
        }

        public async Task<StateEntity> GetState(int StateID) {
            StateEntity result;

            result = await context.State 
                .FirstOrDefaultAsync(x => x.ID == StateID);

            return result;
        }

        public async Task<CountryEntity> GetCountry(int CountryID) {
            CountryEntity result;

            result = await context.Country
                .FirstOrDefaultAsync(x => x.ID == CountryID);

            return result;
        }
    }
}
