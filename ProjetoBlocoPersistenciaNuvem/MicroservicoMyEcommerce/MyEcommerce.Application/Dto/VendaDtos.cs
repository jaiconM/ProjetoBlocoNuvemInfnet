using System.ComponentModel.DataAnnotations;

namespace MyEcommerce.Application.Dto;

public record VendaInputDto(
    [Required(ErrorMessage = "Data é obrigatória")]
    DateTime Data,
    [Required(ErrorMessage = "Cliente é obrigatório")]
    Guid ClienteId,
    string? Vendedor,
    [Required(ErrorMessage = "Itens da Venda são obrigatórios")]
    List<ItemVendaInputDto> ItensVenda
);

public record VendaOutputDto(
    Guid Id,
    DateTime Data,
    ClienteOutputDto Cliente,
    string Vendedor,
    decimal ValorTotal,
    List<ItemVendaOutputDto> ItensVenda
);

public record ItemVendaInputDto(
    [Required(ErrorMessage = "Código do Produto é obrigatório")]
    string CodigoProduto,
    [Required(ErrorMessage = "Produto é obrigatório")]
    string Produto,
    [Required(ErrorMessage = "Quantidade é obrigatória")]
    decimal Quantidade,
    [Required(ErrorMessage = "Valor Unitário é obrigatória")]
    decimal ValorUnitario
);

public record ItemVendaOutputDto(
    Guid Id,
    string CodigoProduto,
    string Produto,
    decimal Quantidade,
    decimal ValorUnitario,
    decimal ValorTotal
);
