using Microsoft.AspNetCore.Mvc;
using WpfAppService.Dtos;
using WpfAppService.Services;

namespace WpfAppService.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    private readonly RegisterService _registerService;

    public AccountController(AccountService accountService, RegisterService registerService)
    {
        _accountService = accountService;
        _registerService = registerService;
    }

    [HttpPost("register")]
    public async ValueTask<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        if (ModelState.IsValid == false)
            return BadRequest(ModelState);
        
        var isAccountExists = await _registerService.ExistsAsync(registerDto, ModelState);
        if (isAccountExists)
            return BadRequest(ModelState);

        await _accountService.AddAsync(registerDto);
        return Ok("Account successfully created");
    }

    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        if (ModelState.IsValid == false)
            return BadRequest(ModelState);

        var isAccountExists = await _accountService.ExistsAsync(loginDto, ModelState);
        if (isAccountExists == false)
            return BadRequest(ModelState);
        
        return Ok("Logged in successfully");
    }
}