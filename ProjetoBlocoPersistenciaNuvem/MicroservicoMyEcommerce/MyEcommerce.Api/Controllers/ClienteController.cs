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
public class ClienteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClienteController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("ListarTodos")]
    public async Task<IActionResult> ListarTodos()
    {
        GetAllClienteQueryResponse result = await _mediator.Send(new GetAllClienteQuery());
        return Ok(result.Clientes);
    }

    [HttpPost("Criar")]
    public async Task<IActionResult> Criar(ClienteInputDto dto)
    {
        CreateClienteCommandResponse result = await _mediator.Send(new CreateClienteCommand(dto));
        return Created($"{result.Cliente.Id}", result.Cliente);
    }

    [HttpGet("ListarPorId/{id}")]
    public async Task<IActionResult> ListarPorId(Guid id)
    {
        GetByIdClienteQueryResponse result = await _mediator.Send(new GetByIdClienteQuery(id));
        return Ok(result.Cliente);
    }

    [HttpPut("Atualizar/{id}")]
    public async Task<IActionResult> Atualizar(Guid id, ClienteInputDto dto)
    {
        UpdateClienteCommandResponse result = await _mediator.Send(new UpdateClienteCommand(id, dto));
        return Ok(result.Cliente);
    }

    [HttpDelete("Excluir/{id}")]
    public async Task<IActionResult> Excluir(Guid id)
    {
        await _mediator.Send(new DeleteClienteCommand(id));
        return Ok("Exclusão realizada com sucesso!");
    }
}