namespace MAL.API.Models.Forum;

using Newtonsoft.Json;

public class ForumTopic
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; } = string.Empty;

    [JsonProperty("created_by")]
    public User CreatedBy { get; set; } = new User();

    [JsonProperty("posts_count")]
    public int PostsCount { get; set; }

    [JsonProperty("last_post")]
    public LastPost LastPost { get; set; } = new LastPost();
}