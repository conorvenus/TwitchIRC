using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using TwitchIRC;
using TwitchIRC.Types;

IConfiguration configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.Build();

IRCClient ircClient = new IRCClientBuilder()
	.WithAccessToken(configuration["AccessToken"] ?? string.Empty)
	.WithUsername("conor_v")
	.Build();

ircClient.OnReady += OnReady;
ircClient.OnChatMessage += OnChatMessage;
ircClient.Run();

void OnReady()
{
	ircClient.Send("JOIN #boxyfresh");
}

void OnChatMessage(IRCChatMessage message)
{
	Console.WriteLine($"{message.Username}: {message.Content}");
}