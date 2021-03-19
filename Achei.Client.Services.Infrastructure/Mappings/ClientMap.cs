

using Achei.Client.Services.Domain2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Achei.Client.Services.Data.Infra.Mappings {
    public class ClientMap : IEntityTypeConfiguration<ClientEntity> {

        public void Configure(EntityTypeBuilder<ClientEntity> builder) {

            #region Table Definitions

            builder.ToTable("Cliente");
            builder.HasKey(o => o.ID);

            #endregion

            #region Properties

            builder.Property(n => n.ID)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(n => n.CPF)
                .HasColumnName("CPF");

            builder.Property(n => n.Name)
                .HasColumnName("Nome");

            builder.Property(n => n.Email)
                .HasColumnName("Email");

            builder.Property(n => n.Password)
                .HasColumnName("Senha");

            builder.Property(n => n.DDD)
                .HasColumnName("DDD");

            builder.Property(n => n.Phone)
                .HasColumnName("Telefone");

            builder.Property(n => n.Status)
                .HasColumnName("Status");

            builder.Property(n => n.CreationDate)
                .HasColumnName("DataCriacao");

            builder.Property(n => n.AddressID)
                .HasColumnName("EnderecoID");
             
            #endregion

            #region Relationship

            builder.HasOne(c => c.Address)
                .WithMany()
                .HasForeignKey(c => c.AddressID);

            #endregion

        }
    }
}
