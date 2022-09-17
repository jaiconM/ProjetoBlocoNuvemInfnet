using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class CreateVendaCommandResponse
{
    public VendaOutputDto Venda { get; set; }

    public CreateVendaCommandResponse(VendaOutputDto venda)
    {
        Venda = venda;
    }
}
