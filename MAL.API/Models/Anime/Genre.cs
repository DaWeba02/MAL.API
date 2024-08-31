namespace MAL.API.Models.Anime;

using Newtonsoft.Json;

public class Genre
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}