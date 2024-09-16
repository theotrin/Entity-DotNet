using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.Services;

public class UsuarioService
{
    private TokenService _tokenService;
    private SignInManager<Usuario> _signInManager;
    private IMapper _mapper;
    private UserManager<Usuario> _userManager;

    public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _tokenService = tokenService;
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

    public async Task<string> Login(LoginUsuarioDto dto)
    {
        var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
        
        if (!resultado.Succeeded)
        {
            throw new ApplicationException("Falha no Login");
        }

        var usuario = _signInManager
            .UserManager
            .Users
            .FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

        var token = _tokenService.GenerateToken(usuario!);

        return token;
    }
}
