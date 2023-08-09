using TwitchIRC.Core;
using Xunit.Abstractions;

namespace TwitchIRC.Testing
{
	public class IRCClientTests
	{
		private readonly IIRCNetworkWrapper _networkWrapper = Substitute.For<IIRCNetworkWrapper>();
		private IRCClient? _client;

		[Theory]
		[InlineData("AT", "UN", "PASS oauth:AT", "NICK UN")]
		[InlineData("oauth:AT", "UN", "PASS oauth:AT", "NICK UN")]
		public void Authenticate_Should_Run_Correctly(string accessToken, string userName, params string[] commands)
		{
			int callbackNumber = 0;
			_client = new IRCClient(new IRCAuthOptions { AccessToken = accessToken, Username = userName }, _networkWrapper);

			_networkWrapper
				.When(x => x.Send(Arg.Any<string>()))
				.Do(x =>
				{
					if (callbackNumber >= commands.Length) _client.Stop();
					else x.Arg<string>().Should().Be(commands[callbackNumber++]);
				});

			_client.Run();
		}
	}
}