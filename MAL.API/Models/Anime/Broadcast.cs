namespace MAL.API.Models.Anime;

using Newtonsoft.Json;

public class Broadcast
{
    [JsonProperty("day_of_the_week")]
    public string DayOfTheWeek { get; set; } = string.Empty;

    [JsonProperty("start_time")]
    public string StartTime { get; set; } = string.Empty;
}