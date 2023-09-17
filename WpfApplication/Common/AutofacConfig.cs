using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WpfApplication.Services;

namespace WpfApplication.Common;

public static class AutofacConfig
{
    private static readonly IContainer Instance;
    private static readonly object LockObject = new ();

    static AutofacConfig()
    {
        lock (LockObject)
        {
            if(Container == null)
                Instance = Configure();
        }    
    }
    
    public static IContainer Container => Instance;

    private static IContainer Configure()
    {
        var services = new ServiceCollection();
        var builder = new ContainerBuilder();
        
        services.AddHttpClient();
        builder.Populate(services);
        builder.RegisterType<AccountService>().SingleInstance();
        builder.RegisterType<AppConfig>().SingleInstance();
            
        return builder.Build();
    }
}