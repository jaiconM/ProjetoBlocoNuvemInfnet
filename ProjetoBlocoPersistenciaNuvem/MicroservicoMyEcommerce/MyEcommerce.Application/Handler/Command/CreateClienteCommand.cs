using MediatR;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class CreateClienteCommand : IRequest<CreateClienteCommandResponse>
{
    public ClienteInputDto Cliente { get; set; }

    public CreateClienteCommand(ClienteInputDto cliente)
    {
        Cliente = cliente;
    }
}
