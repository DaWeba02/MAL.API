using MAL.API.Helpers;
using MAL.API.Models.Services;

namespace MAL.API.Services;

public class ForumService
{
    private readonly ApiClient _apiClient;

    public ForumService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Gets forum topics.
    /// </summary>
    public async Task<PagedResults<ForumTopic>> GetForumTopicsAsync(string boardId = "", string subboardId = "", string limit = "10", string offset = "0")
    {
        string endpoint = $"forum/topics";
        string queryParams = $"board_id={boardId}&subboard_id={subboardId}&limit={limit}&offset={offset}";
        return await _apiClient.GetAsync<PagedResults<ForumTopic>>(endpoint, queryParams);
    }

    /// <summary>
    /// Gets forum topic details by ID.
    /// </summary>
    public async Task<ForumTopicDetail> GetForumTopicDetailsAsync(int topicId, int limit = 10, int offset = 0)
    {
        string endpoint = $"forum/topic/{topicId}";
        string queryParams = $"limit={limit}&offset={offset}";
        return await _apiClient.GetAsync<ForumTopicDetail>(endpoint, queryParams);
    }
}