using Cadastros.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Cadastros.Domain.Validations;

public class EmailValidator : AbstractValidator<Email>
{
    private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

    public EmailValidator()
    {
        RuleFor(email => email.Valor)
            .NotEmpty()
            .Must(BeAEmailValid).WithMessage("Email inválido");
    }

    private bool BeAEmailValid(string valor) => Regex.IsMatch(valor, Pattern);
}
