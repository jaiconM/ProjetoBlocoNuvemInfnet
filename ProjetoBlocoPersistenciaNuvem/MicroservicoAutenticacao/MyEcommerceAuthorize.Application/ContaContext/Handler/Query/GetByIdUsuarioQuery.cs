﻿using MediatR;

namespace MyEcommerceAuthorize.Application.ContaContext.Handler.Query;

public class GetByIdUsuarioQuery : IRequest<GetByIdUsuarioQueryResponse>
{
    public Guid Id { get; set; }

    public GetByIdUsuarioQuery(Guid id)
    {
        Id = id;
    }
}
