using Cadastros.CrossCutting.BaseEntity;

namespace Cadastros.Domain.Entities;

public class Produto : Entity<Guid>
{
    public string Nome { get; set; }

}