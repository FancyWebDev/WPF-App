namespace WpfApplication.Dtos;

public record RegisterDto
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Email { get; set; }
}