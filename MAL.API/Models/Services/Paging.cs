namespace MAL.API.Models.Services;

using Newtonsoft.Json;

public class Paging
{
    [JsonProperty("previous")]
    public string Previous { get; set; } = string.Empty;

    [JsonProperty("next")]
    public string Next { get; set; } = string.Empty;
}