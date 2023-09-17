using System.ComponentModel.DataAnnotations;

namespace WpfAppService.Dtos;

public record RegisterDto
{
    [Required(ErrorMessage = "Login is required")]
    public string Login { get; init; }

    [Required(ErrorMessage = "Hash password is required")]
    public string PasswordHash { get; init; }

    [Required(ErrorMessage = "Email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; init; }
}