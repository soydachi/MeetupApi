# MeetupApi

![MeetupApi](https://raw.github.com/soydachi/MeetupApi/master/assets/MeetupApiHeader.png)

**Meetup.Api** is a modern, asynchronous .NET library for interacting with the Meetup API.

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://github.com/soydachi/MeetupApi/actions)
[![NuGet](https://img.shields.io/nuget/v/Meetup.Api.svg)](https://www.nuget.org/packages/Meetup.Api/)
[![License](https://img.shields.io/github/license/soydachi/MeetupApi.svg)](LICENSE)

## Features

- **.NET 10 Support**: Built for the latest .NET ecosystem.
- **Dependency Injection**: Designed with `IMeetupClient` and `IHttpClientFactory` for easy integration into modern .NET applications.
- **Asynchronous**: Fully async/await support for all API calls.
- **Strongly Typed**: Comprehensive models for Meetup API responses (Events, Groups, Venues, etc.).
- **No Hardcoded Secrets**: Secure design requiring configuration injection.

## Installation

Install the package via NuGet:

```bash
dotnet add package Meetup.Api
```

## Getting Started

### 1. Register the Service

In your `Program.cs` or `Startup.cs`, register the Meetup API client:

```csharp
using Meetup.Api;

var builder = WebApplication.CreateBuilder(args);

// Add MeetupApi to the container
builder.Services.AddMeetupApi(client =>
{
    // Optional: Configure the HttpClient here (e.g., headers, timeouts)
    // Note: Authentication is typically handled via OAuth tokens passed in headers
});

var app = builder.Build();
```

### 2. Use IMeetupClient

Inject `IMeetupClient` into your services or controllers:

```csharp
public class MyMeetupService
{
    private readonly IMeetupClient _meetupClient;

    public MyMeetupService(IMeetupClient meetupClient)
    {
        _meetupClient = meetupClient;
    }

    public async Task<bool> CheckApiStatusAsync()
    {
        return await _meetupClient.GetStatusAsync();
    }

    public async Task<IEnumerable<Event>> GetEventsAsync(string groupUrlName)
    {
        var events = await _meetupClient.GetEventsAsync(groupUrlName);
        return events.Results;
    }
}
```

## Usage Examples

### Get Group Events
```csharp
var events = await _client.GetEventsAsync("CrossDevelopment-Madrid");
foreach (var meetup in events.Results)
{
    Console.WriteLine($"Event: {meetup.Name} at {meetup.Time}");
}
```

### Get Discussion Boards
```csharp
var boards = await _client.GetBoardsAsync("CrossDevelopment-Madrid");
```

### Create an Event
```csharp
var newEvent = new CreateEventModel
{
    Name = "Monthly Meetup",
    Description = "Join us for...",
    Time = DateTimeOffset.UtcNow.AddDays(7).ToUnixTimeMilliseconds(),
    Duration = 7200000 // 2 hours
};

await _client.CreateEventAsync("CrossDevelopment-Madrid", "Monthly Meetup", newEvent);
```

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for details on how to submit pull requests, report issues, and the code of conduct.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

Copyright (c) 2019-2025 Dachi Gogotchuri
