using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Models;
using UsersApi.Services;

namespace UsersApi.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController : ControllerBase
{

    private CadastroService _cadastroService;

    public UsuarioController(CadastroService cadastroService)
    {
        _cadastroService = cadastroService;
    }

    [HttpPost]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        await _cadastroService.Cadastra(dto);
        return Ok("Usuario Cadastrado!");
    }
}
