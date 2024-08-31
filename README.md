# MyAnimeList API Client

This is a C# client library for accessing the MyAnimeList API. It allows developers to interact with various features of the MyAnimeList platform, including retrieving information about anime, manga, user profiles, and forum topics. This client library is open-source and released under the MIT License.

## Table of Contents

- [Introduction](#introduction)
- [Installation](#installation)
- [Usage](#usage)
  - [Authentication](#authentication)
  - [Anime Service](#anime-service)
  - [Manga Service](#manga-service)
  - [User Service](#user-service)
  - [Forum Service](#forum-service)
- [Features](#features)
- [Dependencies](#dependencies)
- [Contributing](#contributing)
- [License](#license)

## Introduction

This library provides a simple and easy-to-use interface for interacting with the MyAnimeList API. It supports common operations such as searching for anime or manga, retrieving user information, and accessing forum topics. This client is designed to be integrated into .NET applications.

## Installation

Add the library manually to your project file:

```xml
<PackageReference Include="MyAnimeListClient" Version="1.0.0" />
```

## Usage

### Authentication

To start using the API, you need to authenticate with MyAnimeList using OAuth2. The `AuthenticationService` class provides methods to generate the authorization URL, exchange an authorization code for an access token, and refresh tokens.

```csharp
var authService = new AuthenticationService(clientId, clientSecret, redirectUri);
string authUrl = authService.GetAuthorizationUrl("your_state_value");

// After redirecting the user and obtaining the authorization code:
var tokenResponse = await authService.GetAccessTokenAsync("authorization_code");
```

### Anime Service

The `AnimeService` allows you to search for anime, retrieve details, and access top-ranking or seasonal anime.

```csharp
var client = new MyAnimeListClient("your_access_token");
var animeDetails = await client.Anime.GetAnimeDetailsAsync(animeId);
var searchResults = await client.Anime.SearchAnimeAsync("Naruto");
```

### Manga Service

The `MangaService` provides similar functionality for manga, including searching, retrieving details, and accessing top manga rankings.

```csharp
var mangaDetails = await client.Manga.GetMangaDetailsAsync(mangaId);
var topManga = await client.Manga.GetTopMangaAsync();
```

### User Service

The `UserService` allows you to retrieve details about the authenticated user, manage their anime list, and more.

```csharp
var userDetails = await client.User.GetOwnUserDetailsAsync();
var userAnimeList = await client.User.GetUserAnimeListAsync();
```

### Forum Service

The `ForumService` enables access to forum topics and their details.

```csharp
var forumTopics = await client.Forum.GetForumTopicsAsync();
var topicDetails = await client.Forum.GetForumTopicDetailsAsync(topicId);
```

## Features

- **OAuth2 Authentication**: Securely access the MyAnimeList API using OAuth2.
- **Anime and Manga Search**: Search and retrieve detailed information on anime and manga.
- **User Profile Management**: Access and manage user profiles and anime lists.
- **Forum Access**: Retrieve and explore MyAnimeList forum topics.

## Dependencies

This project relies on the following dependencies:

- **Newtonsoft.Json**: Used for JSON serialization and deserialization.
- **System.Net.Http**: For making HTTP requests to the MyAnimeList API.

These dependencies are automatically included when you add the package via NuGet.

## Contributing

Contributions are welcome! If you find a bug or have a feature request, please open an issue on the [GitHub repository](https://github.com/DaWeba02/MAL.API/). Pull requests are also appreciated.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
