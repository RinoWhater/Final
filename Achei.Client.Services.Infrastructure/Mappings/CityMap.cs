using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Achei.Client.Services.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achei.Client.Services.Data.Infra.Mappings {
    public class CityMap : IEntityTypeConfiguration<CityEntity> {
        public void Configure(EntityTypeBuilder<CityEntity> builder) {

            #region Table Definitions

            builder.ToTable("Cidade");
            builder.HasKey(o => o.ID);

            #endregion

            #region Properties

            builder.Property(n => n.ID)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(n => n.Name)
                .HasColumnName("Nome");

            builder.Property(n => n.StateID)
                .HasColumnName("EstadoID");

            #endregion

            #region Relationship

            builder.HasOne(c => c.State)
                .WithMany()
                .HasForeignKey(c => c.StateID);

            #endregion

        }
    }
}
