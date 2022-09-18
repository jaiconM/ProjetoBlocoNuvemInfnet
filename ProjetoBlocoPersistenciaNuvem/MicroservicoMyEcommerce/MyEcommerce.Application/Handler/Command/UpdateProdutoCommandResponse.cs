using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Command;

public class UpdateProdutoCommandResponse
{
    public ProdutoOutputDto Produto { get; set; }

    public UpdateProdutoCommandResponse(ProdutoOutputDto produto)
    {
        Produto = produto;
    }
}
