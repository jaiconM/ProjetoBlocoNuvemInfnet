using System.ComponentModel.DataAnnotations;

namespace MyEcommerceAuthorize.Application.ContaContext.Dto;

public record UsuarioInputDto(
    [Required(ErrorMessage = "Nome é obrigatório")]
    string Nome,
    [Required(ErrorMessage = "E-mail é obrigatório")]
    string Email,
    [Required(ErrorMessage = "Senha é obrigatória")]
    string Senha
);

public record UsuarioOutputDto(
    Guid Id,
    string Nome,
    string Email
);