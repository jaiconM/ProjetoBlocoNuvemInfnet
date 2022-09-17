using MediatR;

namespace MyEcommerce.Application.Handler.Command;

public class DeleteVendaCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteVendaCommand(Guid id)
    {
        Id = id;
    }
}
