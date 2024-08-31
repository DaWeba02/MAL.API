namespace MAL.API.Models.Manga;

using Newtonsoft.Json;

public class Author
{
    [JsonProperty("node")]
    public AuthorNode Node { get; set; } = new AuthorNode();

    [JsonProperty("role")]
    public string Role { get; set; } = string.Empty;
}