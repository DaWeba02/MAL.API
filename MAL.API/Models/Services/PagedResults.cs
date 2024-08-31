namespace MAL.API.Models.Services;

using Newtonsoft.Json;

public class PagedResults<T>
{
    [JsonProperty("data")]
    public List<PagedResult<T>> Data { get; set; } = [];

    [JsonProperty("paging")]
    public Paging Paging { get; set; } = new Paging();
}