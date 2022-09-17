using MyEcommerce.CrossCutting.BaseEntity;
using MyEcommerce.Domain.ValueObjects;

namespace MyEcommerce.Domain;

public class Cliente : Entity<Guid>
{
    public string Nome { get; set; }
    public Email Email { get; set; }
    public string Endereco { get; set; }
    protected Cliente() { /* for EF */ }

    public Cliente(string nome, Email email, string endereco)
    {
        Nome = nome;
        Email = email;
        Endereco = endereco;
    }

    public Cliente(Guid id)
    {
        Id = id;
    }
}