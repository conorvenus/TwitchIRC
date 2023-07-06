namespace TwitchIRC
{
	public class IRCClientBuilder
	{
		private IRCHost _host = new IRCHost("irc.chat.twitch.tv", 6667);

		public IRCClientBuilder WithHost(IRCHost host) {
			_host = host;
			return this;
		}

		public IRCClient Build() => new IRCClient(_host);
	}
}