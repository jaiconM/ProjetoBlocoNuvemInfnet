using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEcommerce.Domain;

namespace MyEcommerce.Data.Mapeamento;

public class ClienteMapping : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Cliente");
        builder.HasKey(cliente => cliente.Id);

        builder.Property(cliente => cliente.Id).ValueGeneratedOnAdd();
        builder.Property(cliente => cliente.Nome).IsRequired().HasMaxLength(200);
        builder.OwnsOne(usuario => usuario.Email, usuarioEmail =>
        {
            usuarioEmail.Property(email => email.Valor).HasColumnName("Email").IsRequired().HasMaxLength(500);
        });
        builder.Property(cliente => cliente.Endereco).HasMaxLength(500);
    }
}
