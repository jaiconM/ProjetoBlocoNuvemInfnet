using System.ComponentModel.DataAnnotations;

namespace MyEcommerce.Application.Dto;

public record ClienteInputDto(
    [Required(ErrorMessage = "Nome é obrigatório")]
    string Nome,
    string? Email,
    string? Endereco
);

public record ClienteOutputDto(
    Guid Id,
    string Nome,
    string? Email,
    string? Endereco
);