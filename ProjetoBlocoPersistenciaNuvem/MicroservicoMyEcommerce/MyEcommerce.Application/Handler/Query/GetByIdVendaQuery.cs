using MediatR;

namespace MyEcommerce.Application.Handler.Query;

public class GetByIdVendaQuery : IRequest<GetByIdVendaQueryResponse>
{
    public Guid Id { get; set; }

    public GetByIdVendaQuery(Guid id)
    {
        Id = id;
    }
}
