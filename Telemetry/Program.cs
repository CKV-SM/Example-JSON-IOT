using CarSimulator;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using System.Text.Json;
using Telemetry.DTO;

internal class Program
{
    private static async Task Main(string[] args)
    {
        IConfigurationRoot _config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

        if (string.IsNullOrEmpty(_config["apiKey"]))
        {
            throw new Exception("You forgot to set your API-key");
        }

        HttpClient apiClient = new()
        {
            BaseAddress = new Uri("https://api.thingspeak.com")
        };

        Car telemetryCar = new();
        telemetryCar.SimulateTrip();
        var simulation = telemetryCar.ExportData();
        TelemetryDTO telemetry = new()
        {
            ApiKey = _config["apiKey"]!,
            CreatedAt = DateTime.UtcNow,
            Rpm = simulation.Rpm,
            Speed = simulation.Speed,
            EngineTemp = simulation.EngineTemp,
            FuelLevel = simulation.FuelLevel
        };

//        await apiClient.PostAsJsonAsync("/update.json", telemetry);

        string payload = JsonSerializer.Serialize(telemetry);
        Console.WriteLine(payload);
    }
}