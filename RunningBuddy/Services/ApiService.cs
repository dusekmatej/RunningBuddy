using System.Diagnostics;
using System.Net.Http.Json;
using RunningBuddy.Models;

namespace RunningBuddy.Services;

public class ApiService
{
    
    private const string URL = "https://api.openweathermap.org/data/2.5/weather";
    private const string KEY = "cf2ba23f25fa8adc08c450fedfe8cbde";
    
    private readonly HttpClient _httpClient;
    
    private ApiList? _storedData0;
    private ApiList? _storedData1;
    private ApiList? _dataStorage;
    
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

        if (AppState.FirstCity == city)
        {
            //  && DateTime.Now - _timeStamp < _Duration
            if (_storedData0 != null)
            {
                Logging.Log("Getting stored data 0");
                return _storedData0;
            }

            _storedData0 = GetFromApi(city);

            return _storedData0;
        }

        if (AppState.LastCity == city)
        {
            // && DateTime.Now - _timeStamp < _Duration
            if (_storedData1 != null)
            {
                Logging.Log("Getting stored data 1");
                return _storedData1;
            }

            _storedData1 = GetFromApi(city);

            return _storedData1;
        }
        
        Logging.Log("One of the cities in AppState is null!");
        return null;
    }

    private ApiList? GetFromApi(string city)
    {
        string requestUrl = $"{URL}?q={city}&units=metric&appid={KEY}";
        
        HttpResponseMessage responseMessage = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();
        _rawResponse = responseMessage.Content
            .ReadAsStringAsync().GetAwaiter().GetResult();
        
        _dataStorage = System.Text.Json.JsonSerializer.Deserialize<ApiList>(_rawResponse);

        return _dataStorage;
    }

    public bool DoesCityExist(string city)
    {
        string requestUrl = $"{URL}?q={city}&units=metric&appid={KEY}";

        HttpResponseMessage response = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode)
        {
            Logging.Log("City found + " + city);
            return true;
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Logging.Log("City not found + " + city);
            return false;
        }

        return false;
    }
}