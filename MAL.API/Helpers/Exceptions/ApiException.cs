namespace MAL.API.Helpers.Exceptions;

public class ApiException : Exception
{
    public System.Net.HttpStatusCode StatusCode { get; }
    public string Content { get; }

    public ApiException(System.Net.HttpStatusCode statusCode, string content)
        : base($"API Request failed with status code {(int)statusCode}")
    {
        StatusCode = statusCode;
        Content = content;
    }
}