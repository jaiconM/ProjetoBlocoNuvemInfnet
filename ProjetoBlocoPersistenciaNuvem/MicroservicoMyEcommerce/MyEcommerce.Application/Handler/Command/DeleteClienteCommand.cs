using MediatR;

namespace MyEcommerce.Application.Handler.Command;

public class DeleteClienteCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteClienteCommand(Guid id)
    {
        Id = id;
    }
}
