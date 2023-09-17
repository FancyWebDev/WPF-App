using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Newtonsoft.Json;
using WpfApplication.Common;
using WpfApplication.Dtos;

namespace WpfApplication.Services;

public class AccountService
{
    private readonly AppConfig _appConfig;
    private readonly HttpClient _client;

    public AccountService()
    {
        _appConfig = AutofacConfig.Container.Resolve<AppConfig>();
        _client = AutofacConfig.Container
            .Resolve<IHttpClientFactory>()
            .CreateClient();
    }
    
    public async ValueTask<HttpResponseMessage> Send(RegisterDto registerDto)
    {
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(_appConfig.ApiBaseUrl + "account/register", content);
        return response;
    }
}