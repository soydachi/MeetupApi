# MeetupApi Usage Guide

This guide provides step-by-step instructions for configuring, authenticating, and using the **MeetupApi** library in your .NET applications.

## 1. Prerequisites

Before using the library, you need:
1.  A **Meetup Pro** account (or a standard account if using public data only, though most endpoints require auth).
2.  An **OAuth Consumer** created in the [Meetup API Dashboard](https://www.meetup.com/api/oauth/list/).
    -   Note your `Key` (Client ID) and `Secret` (Client Secret).
    -   Set a `Redirect URI` (e.g., `http://localhost:5000/callback` for local testing).

## 2. Authentication

The Meetup API uses **OAuth 2.0**. The `MeetupApi` library relies on you to provide an authenticated `HttpClient`.

### Obtaining an Access Token

You need to implement the OAuth flow to get an access token. Here is a high-level overview:

1.  **Request Authorization**: Redirect the user to:
    ```
    https://secure.meetup.com/oauth2/authorize?client_id={YOUR_CLIENT_ID}&response_type=code&redirect_uri={YOUR_REDIRECT_URI}
    ```
2.  **Get Code**: After the user logs in, Meetup redirects to your URI with a `code` parameter.
3.  **Exchange Code for Token**: POST to `https://secure.meetup.com/oauth2/access` with:
    -   `client_id`
    -   `client_secret`
    -   `grant_type=authorization_code`
    -   `redirect_uri`
    -   `code`

The response will contain an `access_token`.

## 3. Installation

Install the package via NuGet:

```bash
dotnet add package Meetup.Api
```

## 4. Configuration

The library uses `IMeetupClient`. The best way to use it is via Dependency Injection.

### Setup in Program.cs

```csharp
using Meetup.Api;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// 1. Retrieve your access token (e.g., from configuration, database, or current user session)
string accessToken = builder.Configuration["Meetup:AccessToken"];

// 2. Register MeetupApi
builder.Services.AddMeetupApi(client =>
{
    client.BaseAddress = new Uri("https://api.meetup.com");
    
    // IMPORTANT: Add the Authorization header
    client.DefaultRequestHeaders.Authorization = 
        new AuthenticationHeaderValue("Bearer", accessToken);
});

var app = builder.Build();
```

## 5. Usage Examples

Once injected, use `IMeetupClient` to interact with the API.

### Get Authenticated User

```csharp
public class MyService
{
    private readonly IMeetupClient _client;

    public MyService(IMeetupClient client)
    {
        _client = client;
    }

    public async Task PrintUserInfo()
    {
        var user = await _client.GetSelfAsync();
        Console.WriteLine($"Hello, {user.Name}!");
    }
}
```

### Get Group Events

```csharp
var events = await _client.GetEventsAsync("my-group-urlname");
foreach (var evt in events.Results)
{
    Console.WriteLine($"Event: {evt.Name} at {evt.Time}");
}
```

## 6. Running Tests

To run the unit tests for this library:

1.  Clone the repository.
2.  Navigate to the root directory.
3.  Run the tests using the dotnet CLI:

```bash
dotnet test
```

Or use the VS Code task:
1.  Press `Cmd+Shift+P`.
2.  Type `Tasks: Run Task`.
3.  Select `test`.

## 7. Troubleshooting

-   **401 Unauthorized**: Ensure your `access_token` is valid and not expired. You may need to use a Refresh Token flow to get a new one.
-   **GraphQL Errors**: Check the `ExecuteQueryAsync` exception message for details on invalid queries or permissions.
