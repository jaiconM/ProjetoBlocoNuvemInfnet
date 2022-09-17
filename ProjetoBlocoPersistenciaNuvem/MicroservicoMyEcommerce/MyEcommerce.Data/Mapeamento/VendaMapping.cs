using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEcommerce.Domain;

namespace MyEcommerce.Data.Mapeamento;

public class VendaMapping : IEntityTypeConfiguration<Venda>
{
    public void Configure(EntityTypeBuilder<Venda> builder)
    {
        builder.ToTable("Venda");
        builder.HasKey(venda => venda.Id);

        builder.Property(venda => venda.Id).ValueGeneratedOnAdd();
        builder.Property(venda => venda.Data).IsRequired();
        builder.Property(venda => venda.Vendedor).HasMaxLength(100);
        builder.HasOne(venda => venda.Cliente);
        builder.HasMany(venda => venda.ItensVenda).WithOne().OnDelete(DeleteBehavior.Cascade);
    }
}
