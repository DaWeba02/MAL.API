namespace MAL.API.Models.Anime;

using MAL.API.Models.Shared;
using Newtonsoft.Json;

public class Anime
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("main_picture")]
    public Picture MainPicture { get; set; } = new Picture();

    [JsonProperty("alternative_titles")]
    public AlternativeTitles AlternativeTitles { get; set; } = new AlternativeTitles();

    [JsonProperty("start_date")]
    public string StartDate { get; set; } = string.Empty;

    [JsonProperty("end_date")]
    public string EndDate { get; set; } = string.Empty;

    [JsonProperty("synopsis")]
    public string Synopsis { get; set; } = string.Empty;

    [JsonProperty("mean")]
    public double? Mean { get; set; }

    [JsonProperty("rank")]
    public int? Rank { get; set; }

    [JsonProperty("popularity")]
    public int? Popularity { get; set; }

    [JsonProperty("num_list_users")]
    public int? NumListUsers { get; set; }

    [JsonProperty("num_scoring_users")]
    public int? NumScoringUsers { get; set; }

    [JsonProperty("nsfw")]
    public string Nsfw { get; set; } = string.Empty;

    [JsonProperty("genres")]
    public List<Genre> Genres { get; set; } = [];

    [JsonProperty("media_type")]
    public string MediaType { get; set; } = string.Empty;

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("num_episodes")]
    public int? NumEpisodes { get; set; }

    [JsonProperty("start_season")]
    public StartSeason StartSeason { get; set; } = new StartSeason();

    [JsonProperty("broadcast")]
    public Broadcast Broadcast { get; set; } = new Broadcast();

    [JsonProperty("source")]
    public string Source { get; set; } = string.Empty;

    [JsonProperty("average_episode_duration")]
    public int? AverageEpisodeDuration { get; set; }

    [JsonProperty("rating")]
    public string Rating { get; set; } = string.Empty;

    [JsonProperty("studios")]
    public List<Studio> Studios { get; set; } = [];
}