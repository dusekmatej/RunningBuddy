﻿using RunningBuddy.Models;

namespace RunningBuddy.Services;

public class ApiServiceForecast
{
    private const string URL = "https://api.openweathermap.org/data/2.5/forecast";
    private const string KEY = "cf2ba23f25fa8adc08c450fedfe8cbde";

    private readonly HttpClient _httpClient;

    private ForecastList? _storedData0;
    private ForecastList? _storedData1;
    private ForecastList? _dataStorage;

    private string _rawResponse;

    
    // Constructor for HttpClient creation
    public ApiServiceForecast()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(URL);
    }

    // Getting data from stored data if stored data is aviable, otherwise get from API
    public ForecastList? GetData(string city)
    {
        if (AppState.FirstCity == city)
        {
            if (_storedData0 != null)
            {
                Logging.Log("Loading stored stored data 1 " + city);
                return _storedData0;
            }

            _storedData0 = GetFromApi(city);
            return _storedData0;
        }

        if (AppState.LastCity == city)
        {
            if (_storedData1 != null)
            {
                Logging.Log("Loading stored stored data 2 " + city);
                return _storedData1;
            }

            _storedData1 = GetFromApi(city);
            return _storedData1;
        }
        
        if (AppState.FirstCity == null || AppState.LastCity == null)
        {
            Logging.Log("One of the cities in AppState is null!");
            return GetFromApi(city);
        }

        Logging.Log("----- Ran into an issue that is not handled yet!");
        return GetFromApi(city);
    }

    // Getting data from the API
    private ForecastList? GetFromApi(string city)
    {
        string requestUrl = $"{URL}?q={city}&units=metric&appid={KEY}";

        HttpResponseMessage responseMessage = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();
        _rawResponse = responseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();

        _dataStorage = System.Text.Json.JsonSerializer.Deserialize<ForecastList>(_rawResponse);
        return _dataStorage;
    }

    
    // Check if the city exists
    public bool DoesCityExist(string city)
    {
        string requestUrl = $"{URL}?q={city}&units=metric&appid={KEY}";

        HttpResponseMessage response = _httpClient.GetAsync(requestUrl).GetAwaiter().GetResult();

        if (response.IsSuccessStatusCode)
        {
            Logging.Log("City found (forecast) + " + city);
            return true;
        }
        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            Logging.Log("City not found (forecast) + " + city);
            return false;
        }

        return false;
    }
}
