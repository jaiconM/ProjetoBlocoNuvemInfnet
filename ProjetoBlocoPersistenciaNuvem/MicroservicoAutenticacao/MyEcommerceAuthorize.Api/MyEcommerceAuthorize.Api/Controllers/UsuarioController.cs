using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyEcommerceAuthorize.Application.ContaContext.Dto;
using MyEcommerceAuthorize.Application.ContaContext.Handler.Command;
using MyEcommerceAuthorize.Application.ContaContext.Handler.Query;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyEcommerceAuthorize.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public UsuarioController(IConfiguration configuration, IMediator mediator)
    {
        _configuration = configuration;
        _mediator = mediator;
    }

    [HttpGet("ListarTodos")]
    [Authorize]
    public async Task<IActionResult> ListarTodos()
    {
        GetAllUsuarioQueryResponse result = await _mediator.Send(new GetAllUsuarioQuery());
        return Ok(result.Usuarios);
    }

    [HttpPost("Criar")]
    [Authorize]
    public async Task<IActionResult> Criar(UsuarioInputDto dto)
    {
        CreateUsuarioCommandResponse result = await _mediator.Send(new CreateUsuarioCommand(dto));
        return Created($"{result.Usuario.Id}", result.Usuario);
    }

    [HttpGet("ListarPorId/{id}")]
    [Authorize]
    public async Task<IActionResult> ListarPorId(Guid id)
    {
        GetByIdUsuarioQueryResponse result = await _mediator.Send(new GetByIdUsuarioQuery(id));
        return Ok(result.Usuario);
    }

    [HttpPut("Atualizar/{id}")]
    [Authorize]
    public async Task<IActionResult> Atualizar(Guid id, UsuarioInputDto dto)
    {
        UpdateUsuarioCommandResponse result = await _mediator.Send(new UpdateUsuarioCommand(id, dto));
        return Ok(result.Usuario);
    }

    [HttpDelete("Excluir/{id}")]
    [Authorize]
    public async Task<IActionResult> Excluir(Guid id)
    {
        await _mediator.Send(new DeleteUsuarioCommand(id));
        return Ok("Exclusão realizada com sucesso!");
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Token([FromForm] string email, [FromForm] string senha)
    {
        var autenticado = await _mediator.Send(new AutenticateUsuarioQuery(email, senha));
        if (autenticado == false)
            return Unauthorized();

        var jwtSecret = _configuration["JwtSecret"];
        var audience = _configuration["Audience"];
        var issuer = _configuration["Issuer"];
        return Ok($"Bearer Token: {GerarToken(jwtSecret, audience, issuer, email)}");
    }

    private static string GerarToken(string jwtSecret, string audience, string issuer, string email)
    {
        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(jwtSecret));
        SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

        Claim[] claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("role", "User")
            };

        JwtSecurityToken token = new(issuer,
           audience,
           claims,
           expires: DateTime.Now.AddMinutes(15),
           signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}