using TwitchIRC.Core;
using Xunit.Abstractions;

namespace TwitchIRC.Testing
{
	public class IRCClientTests
	{
		private readonly ITestOutputHelper _output;

		public IRCClientTests(ITestOutputHelper output)
		{
			_output = output;
		}

		[Fact]
		public void Run_Should_Authenticate_Properly()
		{
			var options = new IRCAuthOptions()
			{
				AccessToken = "ACCESS_TOKEN",
				Username = "USERNAME"
			};

			IRCClient? client = null;

			int callback = 0;

			var mockNetworkWrapper = new Mock<IIRCNetworkWrapper>();
			mockNetworkWrapper
				.Setup(m => m.Receive())
				.Returns(string.Empty);
			mockNetworkWrapper
				.Setup(m => m.Send(It.IsAny<string>()))
				.Callback((string s) =>
				{
					if (callback == 0) s.Should().Be($"PASS {options.AccessToken}");
					else if (callback == 1) s.Should().Be($"NICK {options.Username}");
					else client?.Stop();
					callback++;
				});

			client = new IRCClient(options, mockNetworkWrapper.Object);
			client.Run();
		}
	}
}