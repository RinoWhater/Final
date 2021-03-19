using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Achei.Client.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achei.Client.Services.Data.Infra.Mappings {
    public class CountryMap : IEntityTypeConfiguration<CountryEntity> {
        public void Configure(EntityTypeBuilder<CountryEntity> builder) {

            #region Table Definitions

            builder.ToTable("Pais");
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


            #endregion

            #region Relationship


            #endregion

        }
    }
}
