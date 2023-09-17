using WpfAppService.Dtos;
using WpfAppService.Models;

namespace WpfAppService.Helper;

public class Mapper
{
    public Account Map(RegisterDto registerDto)
    {
        return new Account
        {
            Login = registerDto.Login,
            Email = registerDto.Email,
            PasswordHash = registerDto.PasswordHash
        };
    }

    public AccountDto Map(Account account)
    {
        return new AccountDto
        {
            Login = account.Login,
            Email = account.Email
        };
    }
}