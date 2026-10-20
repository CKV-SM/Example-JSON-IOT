using System.Text.Json.Serialization;
public class ReadCarDTO
{
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    [JsonPropertyName("entry_id")]
    public int EntryId { get; set; }

    [JsonPropertyName("field1")]
    public string RPM { get; set; }

    [JsonPropertyName("field2")]
    public string Speed{ get; set; }

    [JsonPropertyName("field3")]
    public string FuelLevel { get; set; }

    [JsonPropertyName("field4")]
    public string EngineTemp { get; set; }
}