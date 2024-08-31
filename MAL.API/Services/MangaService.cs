namespace MAL.API.Services;

using MAL.API.Helpers;
using MAL.API.Models.Manga;
using MAL.API.Models.Services;

public class MangaService
{
    private readonly ApiClient _apiClient;

    public MangaService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    /// <summary>
    /// Gets manga details by ID.
    /// </summary>
    public async Task<Manga> GetMangaDetailsAsync(int mangaId, string fields = "")
    {
        string endpoint = $"manga/{mangaId}";
        string query = string.IsNullOrEmpty(fields) ? "" : $"fields={fields}";
        return await _apiClient.GetAsync<Manga>(endpoint, query);
    }

    /// <summary>
    /// Searches for manga by query.
    /// </summary>
    public async Task<PagedResults<Manga>> SearchMangaAsync(string query, int limit = 10, int offset = 0, string fields = "")
    {
        string endpoint = $"manga";
        string queryParams = $"q={query}&limit={limit}&offset={offset}";
        if (!string.IsNullOrEmpty(fields))
        {
            queryParams += $"&fields={fields}";
        }
        return await _apiClient.GetAsync<PagedResults<Manga>>(endpoint, queryParams);
    }

    /// <summary>
    /// Gets top-ranking manga.
    /// </summary>
    public async Task<PagedResults<Manga>> GetTopMangaAsync(string rankingType = "all", int limit = 10, int offset = 0, string fields = "")
    {
        string endpoint = $"manga/ranking";
        string queryParams = $"ranking_type={rankingType}&limit={limit}&offset={offset}";
        if (!string.IsNullOrEmpty(fields))
        {
            queryParams += $"&fields={fields}";
        }
        return await _apiClient.GetAsync<PagedResults<Manga>>(endpoint, queryParams);
    }
}