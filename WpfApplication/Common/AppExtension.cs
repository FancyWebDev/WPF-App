using System.Text.RegularExpressions;

namespace WpfApplication.Common;

public static class AppExtension
{
    private const string LoginPattern = @"^[a-zA-Z]+$";
    private const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    private const string PasswordPatten = @"^(?=.*[a-zA-Z])(?=.*\d).+$";
    private const int MinLoginLength = 3;
    private const int MinPasswordLength = 5;

    private static readonly Regex LoginRegex = new(LoginPattern);
    private static readonly Regex PasswordRegex = new(PasswordPatten);
    private static readonly Regex EmailRegex = new(EmailPattern);

    public static bool IsPasswordEqual(this string password1, string password2) => 
        string.Equals(password1, password2);

    public static bool IsValidLogin(this string login) => 
        LoginRegex.IsMatch(login) && login.Length >= MinLoginLength;

    public static bool IsPasswordValid(this string password) => 
        PasswordRegex.IsMatch(password) && password.Length >= MinPasswordLength;

    public static bool IsValidEmail(this string email) => EmailRegex.IsMatch(email);
}