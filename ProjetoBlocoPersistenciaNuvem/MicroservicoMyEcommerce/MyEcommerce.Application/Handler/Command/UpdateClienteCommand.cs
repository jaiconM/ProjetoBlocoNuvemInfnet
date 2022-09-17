using MediatR;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class UpdateClienteCommand : IRequest<UpdateClienteCommandResponse>
{
    public Guid Id { get; set; }
    public ClienteInputDto Cliente { get; set; }

    public UpdateClienteCommand(Guid id, ClienteInputDto cliente)
    {
        Id = id;
        Cliente = cliente;
    }
}
