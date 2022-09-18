using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Query;

public class GetByIdProdutoQueryResponse
{
    public ProdutoOutputDto Produto { get; set; }

    public GetByIdProdutoQueryResponse(ProdutoOutputDto produto)
    {
        Produto = produto;
    }
}
