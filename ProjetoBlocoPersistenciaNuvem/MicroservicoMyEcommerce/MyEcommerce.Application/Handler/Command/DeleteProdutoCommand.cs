using MediatR;

namespace MyEcommerce.Application.Handler.Command;

public class DeleteProdutoCommand : IRequest<bool>
{
    public string Id { get; set; }

    public DeleteProdutoCommand(string id)
    {
        Id = id;
    }
}
