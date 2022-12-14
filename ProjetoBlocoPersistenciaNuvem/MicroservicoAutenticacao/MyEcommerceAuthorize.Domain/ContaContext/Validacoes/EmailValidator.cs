using FluentValidation;
using MyEcommerceAuthorize.Domain.ContaContext.ValueObjects;
using System.Text.RegularExpressions;

namespace MyEcommerceAuthorize.Domain.ContaContext.Validacoes;

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
