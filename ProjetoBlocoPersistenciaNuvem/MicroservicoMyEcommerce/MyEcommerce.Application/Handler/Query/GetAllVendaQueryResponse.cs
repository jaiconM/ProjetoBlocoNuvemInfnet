using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Query;

public class GetAllVendaQueryResponse
{
    public IList<VendaOutputDto> Vendas { get; set; }

    public GetAllVendaQueryResponse(IList<VendaOutputDto> vendas)
    {
        Vendas = vendas;
    }
}
