using Cadastros.Domain.Entities;
using FluentValidation;

namespace Cadastros.Domain.Validations;

public class ClienteValidator : AbstractValidator<Cliente>
{
    public ClienteValidator()
    {
        RuleFor(cliente => cliente.Nome).NotEmpty();
        RuleFor(cliente => cliente.Email).SetValidator(new EmailValidator());
    }
}
