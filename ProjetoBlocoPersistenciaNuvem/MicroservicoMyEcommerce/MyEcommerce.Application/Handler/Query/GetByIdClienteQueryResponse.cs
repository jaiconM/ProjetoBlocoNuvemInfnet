using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Query;

public class GetByIdClienteQueryResponse
{
    public ClienteOutputDto Cliente { get; set; }

    public GetByIdClienteQueryResponse(ClienteOutputDto cliente)
    {
        Cliente = cliente;
    }
}
