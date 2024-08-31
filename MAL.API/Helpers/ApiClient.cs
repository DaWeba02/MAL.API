namespace MAL.API.Helpers;

using MAL.API.Helpers.Exceptions;
using Newtonsoft.Json;
using System.Net.Http.Headers;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient(string accessToken)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://api.myanimelist.net/v2/")
        };
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<T> GetAsync<T>(string endpoint, string queryParameters = "")
    {
        var response = await _httpClient.GetAsync($"{endpoint}?{queryParameters}");

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApiException(response.StatusCode, errorContent);
        }

        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(content)!;
    }

    public async Task<T> PostAsync<T>(string endpoint, HttpContent content)
    {
        var response = await _httpClient.PostAsync(endpoint, content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApiException(response.StatusCode, errorContent);
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent)!;
    }

    public async Task<T> PutAsync<T>(string endpoint, HttpContent content)
    {
        var response = await _httpClient.PutAsync(endpoint, content);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApiException(response.StatusCode, errorContent);
        }

        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseContent)!;
    }

    public async Task DeleteAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync(endpoint);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new ApiException(response.StatusCode, errorContent);
        }
    }
}