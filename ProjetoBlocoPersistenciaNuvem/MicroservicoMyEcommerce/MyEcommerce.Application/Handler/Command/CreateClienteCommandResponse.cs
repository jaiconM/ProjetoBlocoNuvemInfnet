using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class CreateClienteCommandResponse
{
    public ClienteOutputDto Cliente { get; set; }

    public CreateClienteCommandResponse(ClienteOutputDto cliente)
    {
        Cliente = cliente;
    }
}
