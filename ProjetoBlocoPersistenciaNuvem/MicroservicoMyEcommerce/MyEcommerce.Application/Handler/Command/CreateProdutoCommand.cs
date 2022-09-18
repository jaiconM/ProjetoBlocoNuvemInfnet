using MediatR;
using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class CreateProdutoCommand : IRequest<CreateProdutoCommandResponse>
{
    public ProdutoInputDto Produto { get; set; }

    public CreateProdutoCommand(ProdutoInputDto produto)
    {
        Produto = produto;
    }
}
