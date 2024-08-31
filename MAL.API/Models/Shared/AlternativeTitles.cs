namespace MAL.API.Models.Shared;

using Newtonsoft.Json;

public class AlternativeTitles
{
    [JsonProperty("synonyms")]
    public List<string> Synonyms { get; set; } = [];

    [JsonProperty("en")]
    public string En { get; set; } = string.Empty;

    [JsonProperty("ja")]
    public string Ja { get; set; } = string.Empty;
}