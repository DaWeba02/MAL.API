﻿namespace MAL.API.Models.Services;

public class TokenResponse
{
    public string TokenType { get; set; } = string.Empty;
    public int ExpiresIn { get; set; }
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}