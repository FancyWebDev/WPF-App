using Autofac;
using WpfApplication.Common;
using WpfApplication.Services;

namespace WpfApplication;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        var navigationService = AutofacConfig.Container.Resolve<NavigationService>();
        MainFrame.Content = navigationService.GetPage(PageType.RegisterPage);
    }
}