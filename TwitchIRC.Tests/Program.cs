using Microsoft.Extensions.Configuration;
using TwitchIRC;
using TwitchIRC.Commands;
using TwitchIRC.Types;

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

client.OnReady += () => client.Send("JOIN #reydempto");
client.OnUserJoin += (string user, string channel) => Console.WriteLine($"{user} joined {channel}!");
client.OnUserPart += (string user, string channel) => Console.WriteLine($"{user} parted {channel}!");
client.Run();