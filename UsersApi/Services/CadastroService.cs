using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public class CadastroService
{
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public CadastroService(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task Cadastra(CreateUsuarioDto dto)
    {
        Usuario usuario = _mapper.Map<Usuario>(dto);

        IdentityResult result = await _userManager.CreateAsync(usuario, dto.Password);

        if (!result.Succeeded)
        {
            throw new ApplicationException("Falha ao cadastar usuário!");
        } 
    }
}
