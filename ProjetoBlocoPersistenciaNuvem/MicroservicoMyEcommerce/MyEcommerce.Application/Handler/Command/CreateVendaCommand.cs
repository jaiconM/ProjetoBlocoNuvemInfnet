using MediatR;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class CreateVendaCommand : IRequest<CreateVendaCommandResponse>
{
    public VendaInputDto Venda { get; set; }

    public CreateVendaCommand(VendaInputDto venda)
    {
        Venda = venda;
    }
}
