using MediatR;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class UpdateProdutoCommand : IRequest<UpdateProdutoCommandResponse>
{
    public string Id { get; set; }
    public ProdutoInputDto Produto { get; set; }

    public UpdateProdutoCommand(string id, ProdutoInputDto produtoiente)
    {
        Id = id;
        Produto = produtoiente;
    }
}
