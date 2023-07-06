using TwitchIRC.Options;

namespace TwitchIRC;

public class IRCClient
{
	private readonly IRCNetworkWrapper _networkWrapper;
	private readonly IRCAuthOptions _authOptions;

	public event EventHandler<string>? OnMessage;

	internal IRCClient(IRCHostOptions hostOptions, IRCAuthOptions authOptions)
	{
		_networkWrapper = new IRCNetworkWrapper(hostOptions);
		_authOptions = authOptions;
	}

	public void Run()
	{
		Authenticate();
		StartReceiving();
	}

	private void Authenticate()
	{
		_networkWrapper.Send($"PASS {_authOptions.AccessToken}");
		_networkWrapper.Send($"NICK {_authOptions.Username}");
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