using Newtonsoft.Json;

namespace MAL.API.Models.Anime;

public class AnimeListEntry
{
    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("score")]
    public int Score { get; set; }

    [JsonProperty("num_watched_episodes")]
    public int NumWatchedEpisodes { get; set; }

    [JsonProperty("is_rewatching")]
    public bool IsRewatching { get; set; }

    [JsonProperty("updated_at")]
    public string UpdatedAt { get; set; } = string.Empty;

    [JsonProperty("anime")]
    public Anime Anime { get; set; } = new Anime();
}