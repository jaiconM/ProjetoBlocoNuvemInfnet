using MyEcommerce.CrossCutting.Interfaces.Data;

namespace MyEcommerce.Domain.Repository;

public interface IVendaRepository : IRepository<Venda>
{
    Task<IEnumerable<Venda>> GetAllWithIncludes();
    Task<Venda> GetByIdWithIncludes(Guid id);
}
