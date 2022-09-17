namespace MyEcommerceAuthorize.Domain.ContaContext.ValueObjects;

public class Senha
{
    public string Valor { get; set; }

    protected Senha() { /* for EF */ }

    public Senha(string senha)
    {
        Valor = senha ?? throw new ArgumentNullException(nameof(senha));
    }

}
