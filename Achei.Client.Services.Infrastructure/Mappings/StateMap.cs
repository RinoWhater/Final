using Achei.Client.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Achei.Client.Services.Data.Infra.Mappings {
    public class StateMap : IEntityTypeConfiguration<StateEntity> {
        public void Configure(EntityTypeBuilder<StateEntity> builder) {

            #region Table Definitions

            builder.ToTable("Estado");
            builder.HasKey(o => o.ID);

            #endregion

            #region Properties

            builder.Property(n => n.ID)
                .HasColumnName("ID")
                .IsRequired();
             
            builder.Property(n => n.Name)
                .HasColumnName("Nome");

            builder.Property(n => n.Acronym)
                .HasColumnName("Sigla");

            builder.Property(n => n.CountryID)
                .HasColumnName("PaisID");

            #endregion

            #region Relationship

            builder.HasOne(c => c.Country)
                .WithMany()
                .HasForeignKey(c => c.CountryID);
            #endregion

        }
    }
}
