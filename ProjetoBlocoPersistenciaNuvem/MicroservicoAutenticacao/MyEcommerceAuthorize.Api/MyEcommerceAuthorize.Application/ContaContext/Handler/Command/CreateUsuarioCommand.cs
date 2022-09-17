using MediatR;
using MyEcommerceAuthorize.Application.ContaContext.Dto;

namespace MyEcommerceAuthorize.Application.ContaContext.Handler.Command;

public class CreateUsuarioCommand : IRequest<CreateUsuarioCommandResponse>
{
    public UsuarioInputDto Usuario { get; set; }

    public CreateUsuarioCommand(UsuarioInputDto usuario)
    {
        Usuario = usuario;
    }
}
