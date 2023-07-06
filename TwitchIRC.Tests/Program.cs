using Microsoft.Extensions.Configuration;
using TwitchIRC;

IConfiguration configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.Build();

IRCClient ircClient = new IRCClientBuilder()
	.WithAccessToken(configuration["AccessToken"] ?? string.Empty)
	.WithUsername("conor_v")
	.Build();

ircClient.OnMessage += OnMessage;
ircClient.Run();

void OnMessage(object? sender, string e)
{
	Console.WriteLine(e);
}