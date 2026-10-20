using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Telemetry.DTO;
public class TelemetryDTO
{

    [JsonPropertyName("api_key")]
    public required string ApiKey { get; init; }
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; init; }
    [JsonPropertyName("field1")]
    public double Rpm { get; init; }
    [JsonPropertyName("field2")]
    public double Speed { get; init; }
    [JsonPropertyName("field3")]
    public double FuelLevel { get; init; }
    [JsonPropertyName("field4")]
    public double EngineTemp { get; init; }
}
