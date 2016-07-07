![GeekyTool](https://raw.github.com/dachibox/MeetupApi/master/assets/MeetupApiHeader.png)

[**Meetup.Api**](https://github.com/dachibox/MeetupApi) is a ***portable class library*** for meetup.

## Install Meetup.Api using NuGet

Comming soon...

## Table of contents

1. [Documentation](https://github.com/dachibox/MeetupApi#documentation)
2. [Example](https://github.com/dachibox/MeetupApi#example)
3. [How to contribute](https://github.com/dachibox/MeetupApi#how-to-contribute)
    - [C# Coding Style](https://github.com/dachibox/MeetupApi#1-c#-coding-style)
    - [How to order functions in file or class](https://github.com/dachibox/MeetupApi#2-how-to-order-functions-in-file-or-class)
    - [Getting Started](https://github.com/dachibox/MeetupApi#3-getting-started)
4. [Author](https://github.com/dachibox/MeetupApi#author)
5. [Contributors](https://github.com/dachibox/MeetupApi#contributors)
5. [License](https://github.com/dachibox/MeetupApi#license)

## Documentation

See [wiki](https://github.com/dachibox/MeetupApi/wiki) _(under construction...)_

## Example

```csharp
var urlName = "CrossDevelopment-Madrid";
var bid = "20671181";
var did = "49893227";

// Fetches a Meetup Event by group urlname and event_id
var result = await MeetupApi.Events.ByIdAsync(urlName, id, CancellationToken.None);

// Listings of Group discussion boards
var result = await MeetupApi.Boards.All(urlName, CancellationToken.None);

// Listings of group discussions
var result = await MeetupApi.Boards.Discussions(urlName, bid, CancellationToken.None);

// Listing Group discussion posts
var result = await MeetupApi.Boards.Discussion(urlName, bid, did, CancellationToken.None);
```

## How to contribute

Contributions are quite welcome, though some rules should be followed!

### 1. C# Coding Style

The general rule we follow is "use Visual Studio defaults".

1. Use [Allman style braces](http://en.wikipedia.org/wiki/Indent_style#Allman_style)
2. Use `camelCase` private members and use `readonly` where possible
3. Avoid `this.` unless absolutely necessary
4. Always specify the visiblity, even if it's the default (i.e. `private string foo` not `string foo`)
5. Namespace imports should be specified at the top of the file, outside of namespace declarations and should be sorted alphabetically, with `System.` namespaces at the top and blank lines between different top level groups

### 2. How to order functions in file or class

- private member, protected member
- private type, public type, protected enum
- public constructor
- public property
- public function, private function

### 3. Getting Started
Just **fork and clone** this repository. Then you need to create in the root `Meetup.Api` the `SecretKeys.cs` class.

```csharp
internal static class SecretKeys
{
    internal const string ApiKey = "";
    internal static readonly string ApiKeyUrl = $"key={ApiKey}&sign=true";
}
```

You can find your ApiKey value here: https://secure.meetup.com/es-ES/meetup_api/key/

> Don't give away your API key. Your key exposes the Meetup groups you've joined, **even private groups.** It's personal and belongs to you, like your account password. If you do want a third party service to be able to use your key temporarily and give them the key, you can reset it by clicking the button below. Once reset, your old key is invalidated and no longer works with our API.

- [x] **Pull request** will only **accepted** from `/dev` branch

## Author

| [![Dachi](https://avatars1.githubusercontent.com/u/1771785?v=3&s=130)](https://github.com/dachibox) |
|---|---|
| [Dachi Gogotchuri](https://github.com/dachibox) |

## Contributors

| [Contributor photo]() |
|---|---|
| [Contributor Name]() |

## License

[MIT License](https://github.com/dachibox/GeekyTool/master/LICENSE)


    Copyright (c) 2016 Dachi Gogotchuri

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
    SOFTWARE.


