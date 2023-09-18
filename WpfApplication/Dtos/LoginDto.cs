using Newtonsoft.Json;

namespace WpfApplication.Dtos;

public class LoginDto
{
    [JsonProperty("login")]
    public string Login { get; set; }
    [JsonProperty("password_hash")]
    public string PasswordHash { get; set; }
}