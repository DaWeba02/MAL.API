namespace MAL.API.Models.Manga;

using Newtonsoft.Json;

public class AuthorNode
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonProperty("last_name")]
    public string LastName { get; set; } = string.Empty;
}