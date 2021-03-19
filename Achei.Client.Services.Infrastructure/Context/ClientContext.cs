using Achei.Client.Services.Data.Infra.Mappings;
using Achei.Client.Services.Domain.Entities;
using Achei.Client.Services.Domain2.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Data.Infra.Context {
    public class ClientContext : DbContext {

        public ClientContext(DbContextOptions options) : base(options) { }

        public DbSet<ClientEntity> Client { get; set; }
        public DbSet<AddressEntity> Address { get; set; }
        public DbSet<CityEntity> City { get; set; }
        public DbSet<StateEntity> State { get; set; }
        public DbSet<CountryEntity> Country { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ClientMap());
            modelBuilder.ApplyConfiguration(new AddressMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
