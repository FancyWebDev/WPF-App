using Microsoft.AspNetCore.Mvc.ModelBinding;
using WpfAppService.Dtos;
using WpfAppService.Helper;
using WpfAppService.Models;
using WpfAppService.Repositories;

namespace WpfAppService.Services;

public class AccountService
{
    private readonly Mapper _mapper;
    private readonly IAccountRepository _accountRepository;

    public AccountService(Mapper mapper, IAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    public ValueTask<IEnumerable<Account>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<Account> GetByAsync(Func<Account, bool> predicate)
    {
        throw new NotImplementedException();
    }

    public async ValueTask AddAsync(RegisterDto registerDto)
    {
        var account = _mapper.Map(registerDto);
        await _accountRepository.AddAsync(account);
    }

    public async ValueTask UpdateAsync()
    {
    }

    public ValueTask DeleteAsync()
    {
        throw new NotImplementedException();
    }

    public async ValueTask<bool> ExistsAsync(LoginDto loginDto, ModelStateDictionary modelStateDictionary)
    {
        var result = await _accountRepository.ExistsAsync(account =>
        {
            return string.Equals(account.Login, loginDto.Login) &&
                   string.Equals(account.PasswordHash, loginDto.PassowordHash);
        });
        
        if(result == false)
            modelStateDictionary.AddModelError("Account", "There's no account with such email/login");

        return result;
    }
}