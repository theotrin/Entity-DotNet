using System.ComponentModel.DataAnnotations;

namespace UsersApi.Data.Dtos;

public class LoginUsuarioDto
{
    [Required]
    public string Username { get; set; }
    [Required] 
    public string Password { get; set; }
}
