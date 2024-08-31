namespace MAL.API.Models.Anime;

using Newtonsoft.Json;

public class Picture
{
    [JsonProperty("medium")]
    public string Medium { get; set; } = string.Empty;

    [JsonProperty("large")]
    public string Large { get; set; } = string.Empty;
}