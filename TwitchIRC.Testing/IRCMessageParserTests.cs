namespace TwitchIRC.Testing
{
	public class IRCMessageParserTests
	{
		[Theory]
		[InlineData(":prefix command param1 param2 :param3", "prefix", "command", "param1", "param2", "param3")]
		[InlineData(":prefix command param1 param2", "prefix", "command", "param1", "param2")]
		[InlineData("command param1 param2 :param3", "", "command", "param1", "param2", "param3")]
		[InlineData("command param1 param2", "", "command", "param1", "param2")]
		[InlineData("command", "", "command")]
		[InlineData(":prefix command", "prefix", "command")]
		public void ParseMessage_Should_Parse_Correctly(string message, string prefix, string command, params string[] parameters)
		{
			IRCMessage parsed = IRCMessageParser.ParseMessage(message);

			parsed.Should().NotBeNull();
			parsed.Prefix.Should().Be(prefix);
			parsed.Command.Should().Be(command);
			parsed.Parameters.Should().BeEquivalentTo(parameters);
		}
	}
}