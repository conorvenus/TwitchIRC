using TwitchIRC;

IRCClient ircClient = new IRCClientBuilder().Build();
ircClient.OnMessage += OnMessage;
ircClient.Run();

void OnMessage(object? sender, string e)
{
	Console.WriteLine(e);
}