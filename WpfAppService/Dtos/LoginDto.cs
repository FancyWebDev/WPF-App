namespace WpfAppService.Dtos;

public record LoginDto
{
    public string Login { get; init; }
    public string PassowordHash { get; init; }
}