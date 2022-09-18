using MediatR;

namespace MyEcommerce.Application.Handler.Query;

public class GetByIdProdutoQuery : IRequest<GetByIdProdutoQueryResponse>
{
    public string Id { get; set; }

    public GetByIdProdutoQuery(string id)
    {
        Id = id;
    }
}
