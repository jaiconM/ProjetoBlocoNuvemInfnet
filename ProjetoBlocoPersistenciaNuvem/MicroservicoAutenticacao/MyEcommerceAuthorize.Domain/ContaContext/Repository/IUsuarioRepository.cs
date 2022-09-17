using MyEcommerceAuthorize.CrossCutting.Interfaces.Data;

namespace MyEcommerceAuthorize.Domain.ContaContext.Repository;

public interface IUsuarioRepository : IRepository<Usuario>
{
    Task<bool> Autentique(string email, string senha);
}
