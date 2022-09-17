using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class UpdateVendaCommandResponse
{
    public VendaOutputDto Venda { get; set; }

    public UpdateVendaCommandResponse(VendaOutputDto venda)
    {
        Venda = venda;
    }
}
