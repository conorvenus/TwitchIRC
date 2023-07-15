<h1 align="center">
    <img width="500px" src="https://imgur.com/FN1ZZ85.png">
</h1>

<p align="center">
  <i align="center">A declarative framework for developing Twitch chat bots in C# 🤖</i>
</p>

## Introduction

TwitchIRC is a framework built in C#, for interacting with the Twitch API. With a strong focus on DX and ease-of-use, TwitchIRC is declarative and modular, with an optional commands framework inspired by other chat bot frameworks.

## Usage

```csharp
using TwitchIRC;
using TwitchIRC.Types;

string channel = ...;

IRCClient client = new IRCClientBuilder()
	.WithAccessToken(...)
	.WithUsername(...)
	.Build();

client.OnReady += () => client.Send($"JOIN #{channel}");
client.OnChatMessage += OnChatMessage;
client.Run();

void OnChatMessage(IRCChatMessage message)
{
	if (message.Content.StartsWith("!ping"))
	{
		client.Send($"PRIVMSG #{channel} :Pong!");
	}
}
```
