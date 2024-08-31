namespace MAL.API.Services;

using MAL.API.Helpers;
using MAL.API.Models.Services;
using MAL.API.Models;
using MAL.API.Models.Anime;

public class UserService
{
    private readonly ApiClient _apiClient;

    public UserService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Gets details of the authenticated user.
    /// </summary>
    public async Task<User> GetOwnUserDetailsAsync(string fields = "")
    {
        string endpoint = $"users/@me";
        string query = string.IsNullOrEmpty(fields) ? "" : $"fields={fields}";
        return await _apiClient.GetAsync<User>(endpoint, query);
    }

    /// <summary>
    /// Gets anime list of the authenticated user.
    /// </summary>
    public async Task<PagedResults<AnimeListEntry>> GetUserAnimeListAsync(string status = "all", int limit = 10, int offset = 0, string sort = "list_score", string fields = "")
    {
        string endpoint = $"users/@me/animelist";
        string queryParams = $"status={status}&sort={sort}&limit={limit}&offset={offset}";
        if (!string.IsNullOrEmpty(fields))
        {
            queryParams += $"&fields={fields}";
        }
        return await _apiClient.GetAsync<PagedResults<AnimeListEntry>>(endpoint, queryParams);
    }

    /// <summary>
    /// Updates anime list entry for the authenticated user.
    /// </summary>
    public async Task<AnimeListEntry> UpdateUserAnimeListEntryAsync(int animeId, int score, string status)
    {
        string endpoint = $"anime/{animeId}/my_list_status";
        var content = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("score", score.ToString()),
                new KeyValuePair<string, string>("status", status)
            });
        return await _apiClient.PutAsync<AnimeListEntry>(endpoint, content);
    }

    /// <summary>
    /// Deletes anime list entry for the authenticated user.
    /// </summary>
    public async Task DeleteUserAnimeListEntryAsync(int animeId)
    {
        string endpoint = $"anime/{animeId}/my_list_status";
        await _apiClient.DeleteAsync(endpoint);
    }
}