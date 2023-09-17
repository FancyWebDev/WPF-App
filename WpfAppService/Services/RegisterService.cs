using Microsoft.AspNetCore.Mvc.ModelBinding;
using WpfAppService.Dtos;
using WpfAppService.Repositories;

namespace WpfAppService.Services;

public class RegisterService
{
    private readonly IAccountRepository _accountRepository;

    public RegisterService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async ValueTask<bool> ExistsAsync(RegisterDto registerDto, ModelStateDictionary modelStateDictionary)
    {
        var isEmailExists = await _accountRepository.ExistsAsync(account => account.Email == registerDto.Email);
        if(isEmailExists)
            modelStateDictionary.AddModelError(nameof(registerDto.Email), "Email is already in use");
        
        var isLoginExists = await _accountRepository.ExistsAsync(account => string.Equals(account.Login, registerDto.Login));
        if(isLoginExists)
            modelStateDictionary.AddModelError(nameof(registerDto.Login), "Login is already in use");

        return isLoginExists || isEmailExists;
    }
}