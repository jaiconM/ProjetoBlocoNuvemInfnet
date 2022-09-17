using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyEcommerce.Domain;

namespace MyEcommerce.Data.Mapeamento;

public class ItemVendaMapping : IEntityTypeConfiguration<ItemVenda>
{
    public void Configure(EntityTypeBuilder<ItemVenda> builder)
    {
        builder.ToTable("ItemVenda");
        builder.HasKey(itemVenda => itemVenda.Id);

        builder.Property(itemVenda => itemVenda.Id).ValueGeneratedOnAdd();
        builder.Property(itemVenda => itemVenda.CodigoProduto).IsRequired().HasMaxLength(200);
        builder.Property(itemVenda => itemVenda.Produto).IsRequired().HasMaxLength(200);
        builder.Property(itemVenda => itemVenda.Quantidade).IsRequired();
        builder.Property(itemVenda => itemVenda.ValorUnitario).IsRequired();
    }
}
