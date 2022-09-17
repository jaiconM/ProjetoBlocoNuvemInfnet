using FluentValidation;
using MyEcommerceAuthorize.CrossCutting.BaseEntity;
using MyEcommerceAuthorize.CrossCutting.Utils;
using MyEcommerceAuthorize.Domain.ContaContext.Validacoes;
using MyEcommerceAuthorize.Domain.ContaContext.ValueObjects;

namespace MyEcommerceAuthorize.Domain.ContaContext;

public class Usuario : Entity<Guid>
{
    public string Nome { get; set; }
    public Email Email { get; set; }
    public Senha Senha { get; set; }

    public void SetPassword() => Senha.Valor = SecurityUtils.HashSHA1(Senha.Valor);

    public void Validate() => new UsuarioValidator().ValidateAndThrow(this);

}