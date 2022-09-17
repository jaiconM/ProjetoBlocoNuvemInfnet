using MyEcommerceAuthorize.Application.ContaContext.Dto;

namespace MyEcommerceAuthorize.Application.ContaContext.Handler.Command;

public class UpdateUsuarioCommandResponse
{
    public UsuarioOutputDto Usuario { get; set; }

    public UpdateUsuarioCommandResponse(UsuarioOutputDto usuario)
    {
        Usuario = usuario;
    }
}
