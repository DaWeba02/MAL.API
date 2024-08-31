namespace MAL.API.Services;

using System.Threading.Tasks;
using MAL.API.Helpers;
using MAL.API.Models.Anime;
using MAL.API.Models.Services;

public class AnimeService
{
    private readonly ApiClient _apiClient;

    public AnimeService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Gets anime details by ID.
    /// </summary>
    public async Task<Anime> GetAnimeDetailsAsync(int animeId, string fields = "")
    {
        string endpoint = $"anime/{animeId}";
        string query = string.IsNullOrEmpty(fields) ? "" : $"fields={fields}";
        return await _apiClient.GetAsync<Anime>(endpoint, query);
    }

    /// <summary>
    /// Searches for anime by query.
    /// </summary>
    public async Task<PagedResults<Anime>> SearchAnimeAsync(string query, int limit = 10, int offset = 0, string fields = "")
    {
        string endpoint = $"anime";
        string queryParams = $"q={query}&limit={limit}&offset={offset}";
        if (!string.IsNullOrEmpty(fields))
        {
            queryParams += $"&fields={fields}";
        }
        return await _apiClient.GetAsync<PagedResults<Anime>>(endpoint, queryParams);
    }

    /// <summary>
    /// Gets top-ranking anime.
    /// </summary>
    public async Task<PagedResults<Anime>> GetTopAnimeAsync(string rankingType = "all", int limit = 10, int offset = 0, string fields = "")
    {
        string endpoint = $"anime/ranking";
        string queryParams = $"ranking_type={rankingType}&limit={limit}&offset={offset}";
        if (!string.IsNullOrEmpty(fields))
        {
            queryParams += $"&fields={fields}";
        }
        return await _apiClient.GetAsync<PagedResults<Anime>>(endpoint, queryParams);
    }

    /// <summary>
    /// Gets seasonal anime.
    /// </summary>
    public async Task<PagedResults<Anime>> GetSeasonalAnimeAsync(int year, string season, int limit = 10, int offset = 0, string sort = "anime_score", string fields = "")
    {
        string endpoint = $"anime/season/{year}/{season}";
        string queryParams = $"sort={sort}&limit={limit}&offset={offset}";
        if (!string.IsNullOrEmpty(fields))
        {
            queryParams += $"&fields={fields}";
        }
        return await _apiClient.GetAsync<PagedResults<Anime>>(endpoint, queryParams);
    }
}