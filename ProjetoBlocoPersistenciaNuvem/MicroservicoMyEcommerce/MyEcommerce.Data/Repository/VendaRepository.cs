using Microsoft.EntityFrameworkCore;
using MyEcommerce.Data.Contexto;
using MyEcommerce.Data.Database;
using MyEcommerce.Domain;
using MyEcommerce.Domain.Repository;

namespace MyEcommerce.Data.Repository;

public class VendaRepository : Repository<Venda>, IVendaRepository
{
    public VendaRepository(MyEcommerceContext context) : base(context) { }
    public async Task<IEnumerable<Venda>> GetAllWithIncludes() => await Query.Include(venda => venda.Cliente)
                                                                             .Include(venda => venda.ItensVenda)
                                                                             .ToListAsync();

    public async Task<Venda> GetByIdWithIncludes(Guid id) => await Query.Include(venda => venda.Cliente)
                                                                        .Include(venda => venda.ItensVenda)
                                                                        .FirstOrDefaultAsync(venda => venda.Id == id);
}
