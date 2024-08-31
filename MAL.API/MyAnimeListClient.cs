namespace MAL.API;

using MAL.API.Helpers;
using MAL.API.Services;

public class MyAnimeListClient
{
    public AnimeService Anime { get; }
    public MangaService Manga { get; }
    public UserService User { get; }
    public ForumService Forum { get; }

    public MyAnimeListClient(string accessToken)
    {
        var apiClient = new ApiClient(accessToken);
        Anime = new AnimeService(apiClient);
        Manga = new MangaService(apiClient);
        User = new UserService(apiClient);
        Forum = new ForumService(apiClient);
    }
}