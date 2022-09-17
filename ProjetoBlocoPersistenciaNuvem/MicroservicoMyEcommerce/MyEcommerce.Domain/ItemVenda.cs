using MyEcommerce.CrossCutting.BaseEntity;

namespace MyEcommerce.Domain;

public class ItemVenda : Entity<Guid>
{
    public string CodigoProduto { get; set; }
    public string Produto { get; set; }
    public decimal Quantidade { get; set; }
    public decimal ValorUnitario { get; set; }
}