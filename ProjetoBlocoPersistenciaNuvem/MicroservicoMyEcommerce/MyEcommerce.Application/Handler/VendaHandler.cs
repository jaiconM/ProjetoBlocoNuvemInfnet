using MediatR;
using MyEcommerce.Application.Handler.Command;
using MyEcommerce.Application.Handler.Query;
using MyEcommerce.Application.Service;

namespace MyEcommerce.Application.Handler;

public class VendaHandler : IRequestHandler<CreateVendaCommand, CreateVendaCommandResponse>,
                              IRequestHandler<GetAllVendaQuery, GetAllVendaQueryResponse>,
                              IRequestHandler<GetByIdVendaQuery, GetByIdVendaQueryResponse>,
                              IRequestHandler<UpdateVendaCommand, UpdateVendaCommandResponse>,
                              IRequestHandler<DeleteVendaCommand, bool>
{
    private readonly IVendaService _vendaService;

    public VendaHandler(IVendaService vendaService)
    {
        _vendaService = vendaService;
    }

    public async Task<CreateVendaCommandResponse> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
    {
        Dto.VendaOutputDto result = await _vendaService.Create(request.Venda);
        return new CreateVendaCommandResponse(result);
    }

    public async Task<GetAllVendaQueryResponse> Handle(GetAllVendaQuery request, CancellationToken cancellationToken)
    {
        List<Dto.VendaOutputDto> result = await _vendaService.GetAll();
        return new GetAllVendaQueryResponse(result);
    }

    public async Task<GetByIdVendaQueryResponse> Handle(GetByIdVendaQuery request, CancellationToken cancellationToken)
    {
        Dto.VendaOutputDto result = await _vendaService.GetById(request.Id);
        return new GetByIdVendaQueryResponse(result);
    }

    public async Task<UpdateVendaCommandResponse> Handle(UpdateVendaCommand request, CancellationToken cancellationToken)
    {
        Dto.VendaOutputDto result = await _vendaService.Update(request.Id, request.Venda);
        return new UpdateVendaCommandResponse(result);
    }

    public async Task<bool> Handle(DeleteVendaCommand request, CancellationToken cancellationToken) => await _vendaService.Delete(request.Id);

}
