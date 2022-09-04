using Cadastros.CrossCutting.BaseEntity;
using Cadastros.Domain.Enums;

namespace Cadastros.Domain.Entities;

public class Produto : Entity<Guid>
{
    public string Nome { get; set; }
    public CategoriaDeProduto Categoria { get; set; }
    public string LinkFoto { get; set; }
    public decimal Valor { get; set; }
}