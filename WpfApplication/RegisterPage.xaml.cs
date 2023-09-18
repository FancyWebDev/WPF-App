using System.Windows;
using Autofac;
using WpfApplication.Common;
using WpfApplication.Dtos;
using WpfApplication.Services;

namespace WpfApplication;

public partial class RegisterPage
{
    private readonly AccountService _accountService;
    private readonly NavigationService _navigationService;

    public RegisterPage(NavigationService navigationService, AccountService accountService)
    {
        InitializeComponent();
        _accountService = accountService;
        _navigationService = navigationService;
    }

    private async void RegisterButtonClicked(object sender, RoutedEventArgs eventArgs)
    {
        if (ValidateInputs(out var registerDto) == false) return;
        
        var response = await _accountService.SendRegister(registerDto);
        MessageBox.Show(response.IsSuccessStatusCode ? "Registered successfully" : "There was some error");
        _navigationService.Navigate(this, PageType.LoginPage);
    }

    private void SignInButtonClicked(object sender, RoutedEventArgs e) => _navigationService.Navigate(this, PageType.LoginPage);

    private bool ValidateInputs(out RegisterDto registerDto)
    {
        registerDto = null;
        var login = LoginBox.Text.Trim();
        var password = PasswordBox.Password.Trim();
        var confirmPassword = ConfirmPasswordBox.Password.Trim();
        var email = EmailBox.Text.Trim().ToLower();

        var isValidLogin = login.IsValidLogin();
        var isValidPassword = password.IsValidPassword();
        var isPasswordEqual = false;
        var isValidEmail = email.IsValidEmail(); 
        
        if(isValidPassword)
            isPasswordEqual = confirmPassword.IsPasswordEqual(password);
        
        if (isValidLogin == false)
            LoginBox.ToolTip = "Login must have at least 3 symbols and 1 letter";
        if (isValidPassword == false)
            PasswordBox.ToolTip = "Invalid password";
        if (isValidPassword && isPasswordEqual == false)
            ConfirmPasswordBox.ToolTip = "Confirm password doesn't match with password";
        if (isValidEmail == false)
            EmailBox.ToolTip = "Invalid email";

        var passwordHash = password.GetPasswordHash();
        
        if (isValidLogin && isValidEmail && isPasswordEqual)
        {
            registerDto = new RegisterDto
            {
                Login = login,
                PasswordHash = passwordHash,
                Email = email
            };
        }
        
        return isValidLogin && isValidEmail && isPasswordEqual;
    }
}