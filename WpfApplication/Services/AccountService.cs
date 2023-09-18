using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WpfApplication.Common;
using WpfApplication.Dtos;

namespace WpfApplication.Services;

public class AccountService
{
    private readonly AppConfig _appConfig;
    private readonly HttpClient _client;
    
    public AccountService(AppConfig config, IHttpClientFactory httpClientFactory)
    {
        _appConfig = config;
        _client = httpClientFactory.CreateClient();
    }
    
    public async ValueTask<HttpResponseMessage> SendRegister(RegisterDto registerDto)
    {
        var content = new StringContent(JsonConvert.SerializeObject(registerDto), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(_appConfig.ApiBaseUrl + "account/register", content);
        return response;
    }

    public async ValueTask<HttpResponseMessage> SendLogin(LoginDto loginDto)
    {
        var content = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
        var response = await _client.PostAsync(_appConfig.ApiBaseUrl + "account/login", content);
        return response;
    }
}