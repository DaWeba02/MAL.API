namespace MAL.API.Models.Forum;

using Newtonsoft.Json;

public class LastPost
{
    [JsonProperty("created_by")]
    public User CreatedBy { get; set; } = new User();

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; } = string.Empty;
}