using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public record WeatherData(Hourly hourly);

public record Hourly(string[] time, float[] temperature_2m, float[] precipitation, float[] wind_speed_10m);

public class Program
{
    public static async Task Main(string[] args)
    {
        using HttpClient client = new HttpClient();
        string url = "https://api.open-meteo.com/v1/forecast?latitude=46.3833&longitude=6.2348&hourly=temperature_2m,precipitation,wind_speed_10m";

        var response = await client.GetStringAsync(url);
        var weatherData = JsonConvert.DeserializeObject<WeatherData>(response);

        // Utilisez weatherData pour les étapes suivantes...
    }
}