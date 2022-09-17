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
public class VendaController : ControllerBase
{
    private readonly IMediator _mediator;

    public VendaController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ListarTodos")]
    public async Task<IActionResult> ListarTodos()
    {
        GetAllVendaQueryResponse result = await _mediator.Send(new GetAllVendaQuery());
        return Ok(result.Vendas);
    }

    [HttpPost("Criar")]
    public async Task<IActionResult> Criar(VendaInputDto dto)
    {
        CreateVendaCommandResponse result = await _mediator.Send(new CreateVendaCommand(dto));
        return Created($"{result.Venda.Id}", result.Venda);
    }

    [HttpGet("ListarPorId/{id}")]
    public async Task<IActionResult> ListarPorId(Guid id)
    {
        GetByIdVendaQueryResponse result = await _mediator.Send(new GetByIdVendaQuery(id));
        return Ok(result.Venda);
    }

    [HttpPut("Atualizar/{id}")]
    public async Task<IActionResult> Atualizar(Guid id, VendaInputDto dto)
    {
        UpdateVendaCommandResponse result = await _mediator.Send(new UpdateVendaCommand(id, dto));
        return Ok(result.Venda);
    }

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> Excluir(Guid id)
    {
        await _mediator.Send(new DeleteVendaCommand(id));
        return Ok("Exclusão realizada com sucesso!");
    }
}