namespace MAL.API.Models;

using Newtonsoft.Json;

public class User
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("picture")]
    public string Picture { get; set; } = string.Empty;
}