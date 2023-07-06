using Microsoft.Extensions.Configuration;
using TwitchIRC;

IConfiguration configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
	.Build();

IRCClient ircClient = new IRCClientBuilder()
	.WithAccessToken(configuration["AccessToken"] ?? string.Empty)
	.WithUsername("conor_v")
	.Build();

ircClient.OnReady += OnReady;
ircClient.OnMessage += OnMessage;
ircClient.Run();

void OnReady()
{
	ircClient.Send("JOIN #ldsylvr");
}

void OnMessage(string message)
{
	Console.WriteLine(message);
}