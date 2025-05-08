using System.Diagnostics;
using System.Net.Http.Json;
using RunningBuddy.Models;

namespace RunningBuddy.Services;

public class ApiService
{
    
    private const string URL = "https://api.openweathermap.org/data/2.5/weather";
    private const string KEY = "cf2ba23f25fa8adc08c450fedfe8cbde";
    
    private readonly HttpClient _httpClient;
    private ApiList? _storedData;
    private DateTime _timeStamp;
    private readonly TimeSpan _Duration = TimeSpan.FromMinutes(10);
    
    private string _rawResponse;
    
    public ApiService()
    {
     _httpClient = new HttpClient();
     _httpClient.BaseAddress = new Uri(URL);
    }

    public ApiList? GetData(string city)
    {
        
        string requestUrl = $"{URL}?q={city}&units=metric&appid={KEY}";
        
        if (_storedData != null && DateTime.Now - _timeStamp < _Duration)
        {
            return _storedData;
        }
        
        HttpResponseMessage responseMessage = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();
        _rawResponse = responseMessage.Content
            .ReadAsStringAsync().GetAwaiter().GetResult();

        _timeStamp = DateTime.Now;
        _storedData = System.Text.Json.JsonSerializer.Deserialize<ApiList>(_rawResponse);

        return _storedData;
    }
}