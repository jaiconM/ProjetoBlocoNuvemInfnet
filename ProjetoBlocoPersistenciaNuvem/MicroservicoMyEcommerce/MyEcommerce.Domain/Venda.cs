using MyEcommerce.CrossCutting.BaseEntity;

namespace MyEcommerce.Domain;

public class Venda : Entity<Guid>
{
    public DateTime Data { get; set; }
    public Cliente Cliente { get; set; }
    public string Vendedor { get; set; }
    public List<ItemVenda> ItensVenda { get; set; }
    public decimal ValorTotal => ItensVenda.Sum(item => item.ValorTotal);
    public Venda()
    {
        ItensVenda = new List<ItemVenda>();
    }
}
