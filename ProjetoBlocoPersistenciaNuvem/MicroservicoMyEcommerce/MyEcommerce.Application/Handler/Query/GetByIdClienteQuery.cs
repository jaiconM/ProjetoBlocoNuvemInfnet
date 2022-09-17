using MediatR;

namespace MyEcommerce.Application.Handler.Query;

public class GetByIdClienteQuery : IRequest<GetByIdClienteQueryResponse>
{
    public Guid Id { get; set; }

    public GetByIdClienteQuery(Guid id)
    {
        Id = id;
    }
}
