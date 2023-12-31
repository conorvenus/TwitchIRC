<h1 align="center">
    <img width="500px" src="https://imgur.com/FN1ZZ85.png">
</h1>

<p align="center">
  <i align="center">A declarative framework for developing Twitch chat bots in C# 🤖</i>
</p>

## Introduction

TwitchIRC is a **pre-alpha** framework built in C#, for interacting with the Twitch API. With a strong focus on DX and ease-of-use, TwitchIRC is declarative and modular, with an optional commands framework inspired by other chat bot frameworks.

## Usage

```csharp
using TwitchIRC;
using TwitchIRC.Types;

IRCClient client = new IRCClientBuilder()
	.WithAccessToken(...)
	.WithUsername(...)
	.Build();

client.OnReady += () => client.Send("JOIN #channel");
client.OnChatMessage += (IRCChatMessage msg) => Console.WriteLine(msg.Content);

client.Run();
```

## Features
- Parses IRC messages.
- Authenticates using `PASS` and `NICK` with Twitch.
- Responds to keep-alives.
- Handles event callbacks for `OnReady`, `OnMessage` and `OnChatMessage`.
- Implemented a declarative command framework using reflection.

## TODO
- [x] Incorporated proper unit testing using xUnit and FluentAssertions.
- [ ] Handle socket disconnects, reconnect requests, etc.
- [ ] Receive Twitch-specific commands and other IRC capabilities.
- [ ] Support the Twitch IRC tags for extra metadata, such as badges, emotes, etc.
- [x] Implemented additional events for `OnUserJoin` and `OnUserPart` of a given channel.
- [ ] Add custom types for users, channels, etc, rather than just using a `string`.
- [ ] Extend the IRC client for use with other parts of the Twitch API, to send whispers, handle alerts, etc.
