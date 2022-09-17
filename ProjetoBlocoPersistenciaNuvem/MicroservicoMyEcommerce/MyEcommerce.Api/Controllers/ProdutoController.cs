using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

    //[HttpGet("ListarTodos")]
    //public async Task<IActionResult> ListarTodos()
    //{
    //    var result = await _mediator.Send(new GetAllProdutoQuery());
    //    return Ok(result.Produtos);
    //}

    //[HttpPost("Criar")]
    //public async Task<IActionResult> Criar(ProdutoInputDto dto)
    //{
    //    var result = await _mediator.Send(new CreateProdutoCommand(dto));
    //    return Created($"{result.Produto.Id}", result.Produto);
    //}

    //[HttpGet("ListarPorId/{id}")]
    //public async Task<IActionResult> ListarPorId(Guid id)
    //{
    //    var result = await _mediator.Send(new GetByIdProdutoQuery(id));
    //    return Ok(result.Produto);
    //}

    //[HttpPut("Atualizar/{id}")]
    //public async Task<IActionResult> Atualizar(Guid id, ProdutoInputDto dto)
    //{
    //    var result = await _mediator.Send(new UpdateProdutoCommand(id, dto));
    //    return Ok(result.Produto);
    //}

    //[HttpDelete("Excluir/{id}")]
    //public async Task<IActionResult> Excluir(Guid id)
    //{
    //    await _mediator.Send(new DeleteProdutoCommand(id));
    //    return Ok("Exclusão realizada com sucesso!");
    //}
}