using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

IConfigurationRoot _config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string? apiKey = _config["apiKey"];
string? channelID = _config["channelID"];

if (string.IsNullOrEmpty(apiKey))
{
    throw new Exception("You forgot to set your API-key");
}

if (string.IsNullOrEmpty(channelID))
{
    throw new Exception("You forgot to set your channel-ID");
}

HttpClient apiClient = new();
apiClient.BaseAddress = new Uri("https://api.thingspeak.com");

string queryAddress = $"/channels/{channelID}/feeds.json?api_key={apiKey}&results=100";

var result = await apiClient.GetFromJsonAsync<Root>(queryAddress);
var results = result?.Feeds;

Console.ReadLine();