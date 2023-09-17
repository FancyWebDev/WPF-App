namespace WpfAppService.Models;

public class Account
{
    public int Id { get; init; }
    public string Login { get; init; }
    public string PasswordHash { get; init; }
    public string Email { get; init; }
}