using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEcommerceAuthorize.Domain.ContaContext;

namespace MyEcommerceAuthorize.Data.Mapeamento;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuarios");
        builder.HasKey(usuario => usuario.Id);

        builder.Property(usuario => usuario.Id).ValueGeneratedOnAdd();
        builder.Property(usuario => usuario.Nome).HasMaxLength(200);
        builder.OwnsOne(usuario => usuario.Email, usuarioEmail =>
        {
            usuarioEmail.Property(email => email.Valor).HasColumnName("Email").IsRequired().HasMaxLength(500);
        });
        builder.OwnsOne(usuario => usuario.Senha, usuarioSenha =>
        {
            usuarioSenha.Property(senha => senha.Valor).HasColumnName("Senha").IsRequired().HasMaxLength(500);
        });
    }
}
