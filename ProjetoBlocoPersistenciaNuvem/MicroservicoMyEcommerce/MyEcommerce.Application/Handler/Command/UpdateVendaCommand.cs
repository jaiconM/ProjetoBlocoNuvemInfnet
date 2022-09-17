using MediatR;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class UpdateVendaCommand : IRequest<UpdateVendaCommandResponse>
{
    public Guid Id { get; set; }
    public VendaInputDto Venda { get; set; }

    public UpdateVendaCommand(Guid id, VendaInputDto venda)
    {
        Id = id;
        Venda = venda;
    }
}
