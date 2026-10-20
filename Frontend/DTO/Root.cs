using System.Text.Json.Serialization;
using System.Collections.Generic;

public class Root
{
    [JsonPropertyName("channel")]
    public Channel Channel { get; set; }

    [JsonPropertyName("feeds")]
    public List<ReadCarDTO> Feeds { get; set; }
}
