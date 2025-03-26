using System.Diagnostics;
using System.Net.Http.Json;
using RunningBuddy.Models;

namespace RunningBuddy.Services;

public class ApiService
{
    
    private const string URL = "https://api.openweathermap.org/data/2.5/weather";
    private const string KEY = "cf2ba23f25fa8adc08c450fedfe8cbde";
    
    private readonly HttpClient _httpClient;
    public ApiService()
    {
     _httpClient = new HttpClient();
     _httpClient.BaseAddress = new Uri(URL);
    }

    public ApiList? GetData(string city)
    {
        try
        {
            string requestUrl = $"{URL}?q={city}&units=metric&appid={KEY}";
            
            HttpResponseMessage response = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();
            
            string rawResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            // Console.WriteLine($"Raw Response: {rawResponse}");

            return System.Text.Json.JsonSerializer.Deserialize<ApiList>(rawResponse);

            //return _httpClient
            //    .GetFromJsonAsync<ApiList>($"{URL}?q={city}&units=metric&appid={KEY}")
            //    .GetAwaiter().GetResult();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);

            return null;
        }
    }
}