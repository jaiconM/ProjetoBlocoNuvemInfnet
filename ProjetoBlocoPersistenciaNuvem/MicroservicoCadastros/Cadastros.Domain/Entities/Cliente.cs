using Cadastros.CrossCutting.BaseEntity;
using Cadastros.CrossCutting.Utils;
using Cadastros.Domain.Validations;
using Cadastros.Domain.ValueObjects;
using FluentValidation;

namespace Cadastros.Domain.Entities;

public class Cliente : Entity<Guid>
{
    public string Nome { get; set; }
    public Email Email { get; set; }
    public Senha Senha { get; set; }

    public void SetPassword() => Senha.Valor = SecurityUtils.HashSHA1(Senha.Valor);

    public void Validate() => new ClienteValidator().ValidateAndThrow(this);
}