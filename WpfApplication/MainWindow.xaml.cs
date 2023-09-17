using System.Windows;
using Autofac;
using WpfApplication.Common;
using WpfApplication.Dtos;
using WpfApplication.Services;

namespace WpfApplication;

public partial class MainWindow
{
    private readonly AccountService _accountService;
        
    public MainWindow()
    {
        _accountService = AutofacConfig.Container.Resolve<AccountService>();
        InitializeComponent();
    }

    private async void RegisterButtonClicked(object sender, RoutedEventArgs eventArgs)
    {
        if (ValidateInputs(out var registerDto) == false) return;
        
        var response = await _accountService.Send(registerDto);
        MessageBox.Show(response.IsSuccessStatusCode ? "Registered successfully" : "There was some error");
    }

    private bool ValidateInputs(out RegisterDto registerDto)
    {
        registerDto = null;
        var login = LoginBox.Text.Trim();
        var password = PasswordBox.Password.Trim();
        var confirmPassword = ConfirmPasswordBox.Password.Trim();
        var email = EmailBox.Text.Trim().ToLower();

        var isValidLogin = login.IsValidLogin();
        var isPasswordValid = password.IsPasswordValid();
        var isPasswordEqual = false;
        var isValidEmail = email.IsValidEmail(); 
        
        if(isPasswordValid)
            isPasswordEqual = confirmPassword.IsPasswordEqual(password);
        
        if (isValidLogin == false)
            LoginBox.ToolTip = "Login must have at least 3 symbols and 1 letter";
        if (isPasswordValid)
            PasswordBox.ToolTip = "Invalid password";
        if (isPasswordValid && isPasswordEqual == false)
            ConfirmPasswordBox.ToolTip = "Confirm password doesn't match with password";
        if (isValidEmail == false)
            EmailBox.ToolTip = "Invalid email";

        if (isValidLogin && isValidEmail && isPasswordEqual)
        {
            registerDto = new RegisterDto
            {
                Login = login,
                Password = password,
                ConfirmPassword = confirmPassword,
                Email = email
            };
        }
        
        return isValidLogin && isValidEmail && isPasswordEqual;
    }
}