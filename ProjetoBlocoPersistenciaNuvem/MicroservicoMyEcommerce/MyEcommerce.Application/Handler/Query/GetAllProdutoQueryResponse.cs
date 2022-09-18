using MyEcommerce.Application.Dto;

namespace MyEcommerce.Application.Handler.Query;

public class GetAllProdutoQueryResponse
{
    public IList<ProdutoOutputDto> Produtos { get; set; }

    public GetAllProdutoQueryResponse(IList<ProdutoOutputDto> produtos)
    {
        Produtos = produtos;
    }
}
