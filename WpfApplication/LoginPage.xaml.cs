using System.Windows;
using Autofac;
using WpfApplication.Common;
using WpfApplication.Dtos;
using WpfApplication.Services;

namespace WpfApplication;

public partial class LoginPage
{
    private readonly AccountService _accountService;
    private readonly NavigationService _navigationService;
    
    public LoginPage(NavigationService navigationService, AccountService accountService)
    {
        InitializeComponent();
        _accountService = accountService;
        _navigationService = navigationService;
    }

    private async void SignInButtonClicked(object sender, RoutedEventArgs e)
    {  
        if(ValidateInputs(out var loginDto) == false) return;
        
        var response = await _accountService.SendLogin(loginDto);
        MessageBox.Show(response.IsSuccessStatusCode ? "Signed In successfully" : "There was some error");
    }

    private void SignUpButtonClicked(object sender, RoutedEventArgs e) => _navigationService.Navigate(this, PageType.RegisterPage);

    private bool ValidateInputs(out LoginDto loginDto)
    {
        loginDto = null;
        var login = LoginBox.Text.Trim();
        var password = PasswordBox.Password.Trim();

        var isValidLogin = string.IsNullOrEmpty(login) == false;
        var isValidPassword = string.IsNullOrEmpty(password) == false;

        if (isValidLogin == false)
            LoginBox.ToolTip = "";
        if (isValidPassword == false)
            PasswordBox.ToolTip = "";

        if (isValidLogin && isValidPassword)
        {
            loginDto = new LoginDto
            {
                Login = login,
                PasswordHash = password.GetPasswordHash()
            };
        }

        return isValidLogin && isValidPassword;
    }
}