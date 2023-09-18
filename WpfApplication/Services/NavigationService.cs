using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApplication.Services;

public class NavigationService
{
    private readonly Dictionary<PageType, Page> _pages;

    public NavigationService(AccountService accountService)
    {
        _pages = new Dictionary<PageType, Page>
        {
            { PageType.LoginPage, new LoginPage(this, accountService) },
            { PageType.RegisterPage, new RegisterPage(this, accountService) }
        };
    }

    public void Navigate(Page page, PageType type) => 
        page.NavigationService?.Navigate(_pages[type]);

    public Page GetPage(PageType type) => _pages[type];
}