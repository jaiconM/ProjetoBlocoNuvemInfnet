using MyEcommerceAuthorize.Application.ContaContext.Dto;

namespace MyEcommerceAuthorize.Application.ContaContext.Handler.Query;

public class GetByIdUsuarioQueryResponse
{
    public UsuarioOutputDto Usuario { get; set; }

    public GetByIdUsuarioQueryResponse(UsuarioOutputDto usuario)
    {
        Usuario = usuario;
    }
}
