using Microsoft.EntityFrameworkCore;
using MyEcommerceAuthorize.Data.Contexto;
using MyEcommerceAuthorize.Data.Database;
using MyEcommerceAuthorize.Domain.ContaContext;
using MyEcommerceAuthorize.Domain.ContaContext.Repository;

namespace MyEcommerceAuthorize.Data.Repository;

public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(MyEcommerceAuthorizeContext context) : base(context) { }

    public async Task<bool> Autentique(string email, string senha)
    {
        List<Usuario> usuarios = await Query.Where(usuario => usuario.Email.Valor == email && usuario.Senha.Valor == senha)
                                            .ToListAsync();
        return usuarios.Any();
    }
}
