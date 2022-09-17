using MyEcommerce.Data.Contexto;
using MyEcommerce.Data.Database;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Data.Repository;

public class ItemVendaRepository : Repository<ItemVenda>, IItemVendaRepository
{
    public ItemVendaRepository(MyEcommerceContext context) : base(context) { }
}
