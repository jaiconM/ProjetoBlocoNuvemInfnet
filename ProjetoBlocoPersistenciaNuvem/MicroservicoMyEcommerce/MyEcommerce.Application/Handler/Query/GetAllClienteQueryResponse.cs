using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Query;

public class GetAllClienteQueryResponse
{
    public IList<ClienteOutputDto> Clientes { get; set; }

    public GetAllClienteQueryResponse(IList<ClienteOutputDto> clientes)
    {
        Clientes = clientes;
    }
}
