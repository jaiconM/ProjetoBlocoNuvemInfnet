using MyEcommerce.Data.Contexto;
using MyEcommerce.Data.Database;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Data.Repository;

public class ClienteRepository : Repository<Cliente>, IClienteRepository
{
    public ClienteRepository(MyEcommerceContext context) : base(context) { }
}
