namespace WpfAppService.Dtos;

public record AccountDto
{
    public string Login { get; init; }
    public string Email { get; init; }
}