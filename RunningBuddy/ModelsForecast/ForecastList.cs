namespace RunningBuddy.ModelsForecast;

public class ForecastList
{
    public string Cod { get; set; }
    public int Message { get; set; }
    public int Cnt { get; set; }
    public List<ForecastEntry> List { get; set; }
    public City City { get; set; }
}