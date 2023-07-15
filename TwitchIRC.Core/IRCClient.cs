using TwitchIRC.Options;
using TwitchIRC.Types;

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
        _networkWrapper.Send("CAP REQ :twitch.tv/membership");
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
			string rawMessage = _networkWrapper.Receive();
			IRCMessage message = IRCMessageParser.ParseMessage(rawMessage);

			switch (message.Command.ToUpper()) {
				case "PING":
					Send("PONG");
					break;
				case "PRIVMSG":
					string username = message.Prefix.Split('!')[0];
					string channel = message.Parameters.First().Substring(1);
					string content = message.Parameters.Last();
					HandleChatMessage(new IRCChatMessage(username, channel, content));
					break;
				case "JOIN":
					username = message.Prefix.Split('!')[0];
					channel = message.Parameters.First()[1..];
					HandleUserJoin(username, channel);
					break;
				case "PART":
                    username = message.Prefix.Split('!')[0];
                    channel = message.Parameters.First()[1..];
					HandleUserPart(username, channel);
					break;
                case "353":
					channel = message.Parameters.SkipLast(1).Last()[1..];
					message.Parameters
						.Last()
						.Split(" ")
						.ToList()
						.ForEach(user => HandleUserJoin(user, channel));
					break;
			};

			HandleMessage(message, rawMessage);
		}
	}
}