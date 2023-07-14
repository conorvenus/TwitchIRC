using Microsoft.Extensions.Configuration;
using TwitchIRC;
using TwitchIRC.Commands;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

IRCClient client = new IRCClientBuilder()
	.WithAccessToken(configuration["AccessToken"] ?? string.Empty)
	.WithUsername("conor_v")
	.Build();

IRCCommandHandler commandHandler = new IRCCommandHandler(client)
	.WithPrefix("?")
	.Register();

client.OnReady += OnReady;
client.Run();

void OnReady()
{
	client.Send("CAP REQ :twitch.tv/membership");
	client.Send("JOIN #conor_v");
}