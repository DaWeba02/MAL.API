namespace MAL.API.Models.Forum;

using Newtonsoft.Json;

public class ForumPost
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("created_by")]
    public User CreatedBy { get; set; } = new User();

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; } = string.Empty;

    [JsonProperty("body")]
    public string Body { get; set; } = string.Empty;
}