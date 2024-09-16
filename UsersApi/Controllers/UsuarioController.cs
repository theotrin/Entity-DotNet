﻿using AutoMapper;
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
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastrarUsuario(CreateUsuarioDto dto)
    {
        await _usuarioService.Cadastra(dto);
        return Ok("Usuario Cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginUsuarioDto dto) 
    {
       var token = await _usuarioService.Login(dto);
        return Ok(token);

    }
}