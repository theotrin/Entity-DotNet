using AutoMapper;
using UsersApi.Data.Dtos;
using UsersApi.Models;

namespace UsersApi.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
