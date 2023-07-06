using TwitchIRC.Options;

namespace TwitchIRC;

public class IRCClient : IRCEventHandler
{
	private readonly IRCNetworkWrapper _networkWrapper;
	private readonly IRCAuthOptions _authOptions;

	internal IRCClient(IRCHostOptions hostOptions, IRCAuthOptions authOptions)
	{
		_networkWrapper = new IRCNetworkWrapper(hostOptions);
		_authOptions = authOptions;
	}

	public void Run()
	{
		Authenticate();
		HandleReady();
		StartReceiving();
	}

	public void Send(string message) => _networkWrapper.Send(message);

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
			HandleMessage(message);
		}
	}
}