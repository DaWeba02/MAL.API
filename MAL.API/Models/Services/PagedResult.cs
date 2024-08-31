namespace MAL.API.Models.Services;

using Newtonsoft.Json;

public class PagedResult<T>
{
    [JsonProperty("node")]
    public T Node { get; set; } = default!;
}