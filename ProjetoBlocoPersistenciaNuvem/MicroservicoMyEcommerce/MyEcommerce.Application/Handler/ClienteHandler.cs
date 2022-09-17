using MediatR;
using MyEcommerce.Application.Handler.Command;
using MyEcommerce.Application.Handler.Query;
using MyEcommerce.Application.Service;

namespace MyEcommerce.Application.Handler;

public class ClienteHandler : IRequestHandler<CreateClienteCommand, CreateClienteCommandResponse>,
                              IRequestHandler<GetAllClienteQuery, GetAllClienteQueryResponse>,
                              IRequestHandler<GetByIdClienteQuery, GetByIdClienteQueryResponse>,
                              IRequestHandler<UpdateClienteCommand, UpdateClienteCommandResponse>,
                              IRequestHandler<DeleteClienteCommand, bool>
{
    private readonly IClienteService _clienteService;

    public ClienteHandler(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    public async Task<CreateClienteCommandResponse> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var result = await _clienteService.Create(request.Cliente);
        return new CreateClienteCommandResponse(result);
    }

    public async Task<GetAllClienteQueryResponse> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
    {
        var result = await _clienteService.GetAll();
        return new GetAllClienteQueryResponse(result);
    }

    public async Task<GetByIdClienteQueryResponse> Handle(GetByIdClienteQuery request, CancellationToken cancellationToken)
    {
        var result = await _clienteService.GetById(request.Id);
        return new GetByIdClienteQueryResponse(result);
    }

    public async Task<UpdateClienteCommandResponse> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
    {
        var result = await _clienteService.Update(request.Id, request.Cliente);
        return new UpdateClienteCommandResponse(result);
    }

    public async Task<bool> Handle(DeleteClienteCommand request, CancellationToken cancellationToken) => await _clienteService.Delete(request.Id);

}
