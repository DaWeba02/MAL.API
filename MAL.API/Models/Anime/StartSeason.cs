namespace MAL.API.Models.Anime;

using Newtonsoft.Json;

public class StartSeason
{
    [JsonProperty("year")]
    public int Year { get; set; }

    [JsonProperty("season")]
    public string Season { get; set; } = string.Empty;
}