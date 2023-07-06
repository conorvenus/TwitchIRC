using TwitchIRC.Options;

namespace TwitchIRC
{
	public class IRCClientBuilder
	{
		private readonly IRCHostOptions _host = new IRCHostOptions("irc.chat.twitch.tv", 6667);
		private readonly IRCAuthOptions _auth = new IRCAuthOptions();

		public IRCClientBuilder WithAccessToken(string accessToken)
		{
			_auth.AccessToken = accessToken;
			return this;
		}

		public IRCClientBuilder WithUsername(string username)
		{
			_auth.Username = username;
			return this;
		}

		public IRCClientBuilder WithHost(string hostName)
		{
			_host.HostName = hostName;
			return this;
		}

		public IRCClientBuilder WithPort(ushort hostPort)
		{
			_host.HostPort = hostPort;
			return this;
		}

		public IRCClient Build() => new IRCClient(_host, _auth);
	}
}