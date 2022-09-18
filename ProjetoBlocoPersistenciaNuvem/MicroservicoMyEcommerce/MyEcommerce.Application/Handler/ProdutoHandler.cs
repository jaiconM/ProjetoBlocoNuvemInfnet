using MediatR;
using MyEcommerce.Application.Handler.Command;
using MyEcommerce.Application.Handler.Query;
using MyEcommerce.Application.Service;

namespace MyEcommerce.Application.Handler;

public class ProdutoHandler : IRequestHandler<CreateProdutoCommand, CreateProdutoCommandResponse>,
                              IRequestHandler<GetAllProdutoQuery, GetAllProdutoQueryResponse>,
                              IRequestHandler<GetByIdProdutoQuery, GetByIdProdutoQueryResponse>,
                              IRequestHandler<UpdateProdutoCommand, UpdateProdutoCommandResponse>,
                              IRequestHandler<DeleteProdutoCommand, bool>
{
    private readonly IProdutoService _produtoService;

    public ProdutoHandler(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public async Task<CreateProdutoCommandResponse> Handle(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        Dto.ProdutoOutputDto result = await _produtoService.Create(request.Produto);
        return new CreateProdutoCommandResponse(result);
    }

    public async Task<GetAllProdutoQueryResponse> Handle(GetAllProdutoQuery request, CancellationToken cancellationToken)
    {
        List<Dto.ProdutoOutputDto> result = await _produtoService.GetAll();
        return new GetAllProdutoQueryResponse(result);
    }

    public async Task<GetByIdProdutoQueryResponse> Handle(GetByIdProdutoQuery request, CancellationToken cancellationToken)
    {
        Dto.ProdutoOutputDto result = await _produtoService.GetById(request.Id);
        return new GetByIdProdutoQueryResponse(result);
    }

    public async Task<UpdateProdutoCommandResponse> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
    {
        Dto.ProdutoOutputDto result = await _produtoService.Update(request.Id, request.Produto);
        return new UpdateProdutoCommandResponse(result);
    }

    public async Task<bool> Handle(DeleteProdutoCommand request, CancellationToken cancellationToken) => await _produtoService.Delete(request.Id);

}
