using Cadastros.CrossCutting.BaseEntity;
using Cadastros.Domain.Validations;
using Cadastros.Domain.ValueObjects;
using FluentValidation;

namespace Cadastros.Domain.Entities;

public class Cliente : Entity<Guid>
{
    public string Nome { get; set; }
    public Email Email { get; set; }

    public void Validate() => new ClienteValidator().ValidateAndThrow(this);
}