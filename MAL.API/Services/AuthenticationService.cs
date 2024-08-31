namespace MAL.API.Services;

using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using MAL.API.Models.Services;
using Newtonsoft.Json;

public class AuthenticationService
{
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _redirectUri;
    private readonly HttpClient _httpClient;

    public AuthenticationService(string clientId, string clientSecret, string redirectUri)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _redirectUri = redirectUri;
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// Generates the URL to redirect users for authorization.
    /// </summary>
    public string GetAuthorizationUrl(string state)
    {
        var uriBuilder = new UriBuilder("https://myanimelist.net/v1/oauth2/authorize");
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);
        query["response_type"] = "code";
        query["client_id"] = _clientId;
        query["redirect_uri"] = _redirectUri;
        query["state"] = state;
        uriBuilder.Query = query.ToString();
        return uriBuilder.ToString();
    }

    /// <summary>
    /// Exchanges authorization code for access token.
    /// </summary>
    public async Task<TokenResponse> GetAccessTokenAsync(string authorizationCode)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://myanimelist.net/v1/oauth2/token");
        var content = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _clientSecret),
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", authorizationCode),
                new KeyValuePair<string, string>("redirect_uri", _redirectUri)
            });
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
        return tokenResponse!;
    }

    /// <summary>
    /// Refreshes the access token using the refresh token.
    /// </summary>
    public async Task<TokenResponse> RefreshAccessTokenAsync(string refreshToken)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "https://myanimelist.net/v1/oauth2/token");
        var content = new FormUrlEncodedContent(new[]
        {
                new KeyValuePair<string, string>("client_id", _clientId),
                new KeyValuePair<string, string>("client_secret", _clientSecret),
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken)
            });
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(responseContent);
        return tokenResponse!;
    }
}