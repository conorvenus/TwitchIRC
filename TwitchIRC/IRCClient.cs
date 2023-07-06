namespace TwitchIRC;

public class IRCClient
{
	private readonly IRCNetworkWrapper _networkWrapper;

	public event EventHandler<string>? OnMessage;

	public IRCClient(IRCHost ircHost)
	{
		_networkWrapper = new IRCNetworkWrapper(ircHost.HostName, ircHost.HostPort);
	}

	public void Run()
	{
		Authenticate();
		StartReceiving();
	}

	private void Authenticate()
	{
		_networkWrapper.Send("PASS oauth:xxx");
		_networkWrapper.Send("NICK xxx");
	}

	private void StartReceiving()
	{
		while (true)
		{
			string message = _networkWrapper.Receive();
			OnMessage?.Invoke(this, message);
		}
	}
}