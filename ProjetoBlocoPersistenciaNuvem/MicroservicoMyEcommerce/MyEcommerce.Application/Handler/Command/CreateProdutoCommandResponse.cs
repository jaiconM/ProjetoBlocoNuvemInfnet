using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class CreateProdutoCommandResponse
{
    public ProdutoOutputDto Produto { get; set; }

    public CreateProdutoCommandResponse(ProdutoOutputDto produto)
    {
        Produto = produto;
    }
}
