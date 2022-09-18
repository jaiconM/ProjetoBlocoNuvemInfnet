using System.ComponentModel.DataAnnotations;

namespace MyEcommerce.Application.Dto;

public record ProdutoInputDto(
    [Required(ErrorMessage = "Código é obrigatório")]
    string Codigo,
    [Required(ErrorMessage = "Nome é obrigatório")]
    string Nome,
    string? LinkFoto,
    [Required(ErrorMessage = "ValorUnitario é obrigatório")]
    double ValorUnitario
);

public record ProdutoOutputDto(
    string RowKey,
    string Codigo,
    string Nome,
    string? LinkFoto,
    double ValorUnitario
);