using MyEcommerceAuthorize.Application.ContaContext.Dto;

namespace MyEcommerceAuthorize.Application.ContaContext.Handler.Command;

public class CreateUsuarioCommandResponse
{
    public UsuarioOutputDto Usuario { get; set; }

    public CreateUsuarioCommandResponse(UsuarioOutputDto usuario)
    {
        Usuario = usuario;
    }
}
