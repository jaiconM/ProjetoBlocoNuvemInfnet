using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEcommerce.Application.Dto;
using MyEcommerce.Application.Handler.Command;
using MyEcommerce.Application.Handler.Query;

namespace MyEcommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProdutoController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProdutoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ListarTodos")]
    public async Task<IActionResult> ListarTodos()
    {
        GetAllProdutoQueryResponse result = await _mediator.Send(new GetAllProdutoQuery());
        return Ok(result.Produtos);
    }

    [HttpPost("Criar")]
    public async Task<IActionResult> Criar(ProdutoInputDto dto)
    {
        CreateProdutoCommandResponse result = await _mediator.Send(new CreateProdutoCommand(dto));
        return Created($"{result.Produto.RowKey}", result.Produto);
    }

    [HttpGet("ListarPorId/{id}")]
    public async Task<IActionResult> ListarPorId(string id)
    {
        GetByIdProdutoQueryResponse result = await _mediator.Send(new GetByIdProdutoQuery(id));
        return Ok(result.Produto);
    }

    [HttpPut("Atualizar/{id}")]
    public async Task<IActionResult> Atualizar(string id, ProdutoInputDto dto)
    {
        UpdateProdutoCommandResponse result = await _mediator.Send(new UpdateProdutoCommand(id, dto));
        return Ok(result.Produto);
    }

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> Excluir(string id)
    {
        await _mediator.Send(new DeleteProdutoCommand(id));
        return Ok("Exclus?o realizada com sucesso!");
    }
}