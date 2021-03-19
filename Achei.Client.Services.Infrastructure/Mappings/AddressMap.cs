using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Achei.Client.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achei.Client.Services.Data.Infra.Mappings {
    public class AddressMap : IEntityTypeConfiguration<AddressEntity> {

        public void Configure(EntityTypeBuilder<AddressEntity> builder) {

            #region Table Definitions

            builder.ToTable("Endereco");
            builder.HasKey(o => o.ID);

            #endregion

            #region Properties

            builder.Property(n => n.ID)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(n => n.Street)
                .HasColumnName("Lagradouro");

            builder.Property(n => n.Number)
                .HasColumnName("Numero");

            builder.Property(n => n.Neighborhood)
                .HasColumnName("Bairro");

            builder.Property(n => n.ZipCode)
                .HasColumnName("CEP");

            builder.Property(n => n.Complement)
                .HasColumnName("Complemento");

            builder.Property(n => n.CityID)
                .HasColumnName("CidadeID");

            #endregion

            #region Relationship

            builder.HasOne(c => c.City)
                .WithMany()
                .HasForeignKey(c => c.CityID);

            #endregion

        }
    }
}
