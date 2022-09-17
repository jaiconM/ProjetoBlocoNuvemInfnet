using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Query;

public class GetByIdVendaQueryResponse
{
    public VendaOutputDto Venda { get; set; }

    public GetByIdVendaQueryResponse(VendaOutputDto venda)
    {
        Venda = venda;
    }
}
