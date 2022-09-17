using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class UpdateClienteCommandResponse
{
    public ClienteOutputDto Cliente { get; set; }

    public UpdateClienteCommandResponse(ClienteOutputDto cliente)
    {
        Cliente = cliente;
    }
}
