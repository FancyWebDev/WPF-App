using System.Text.Json.Serialization;

namespace WpfAppService.Dtos;

public record AccountDto
{
    [JsonPropertyName("login")]
    public string Login { get; init; }
    [JsonPropertyName("email")]
    public string Email { get; init; }
}