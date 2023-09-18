using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WpfAppService.Dtos;

public record RegisterDto
{
    [JsonPropertyName("login")]
    [Required(ErrorMessage = "Login is required")]
    public string Login { get; init; }

    [JsonPropertyName("password_hash")]
    [Required(ErrorMessage = "Password hash is required")]
    public string PasswordHash { get; init; }

    [JsonPropertyName("email")]
    [Required(ErrorMessage = "Email address is required")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; init; }
}