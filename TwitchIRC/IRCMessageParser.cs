using TwitchIRC.Types;

namespace TwitchIRC;

internal static class IRCMessageParser
{
	public static IRCMessage ParseMessage(string message)
	{
		(string prefix, message) = ParsePrefix(message);
		(string command, message) = ParseCommand(message);
		List<string> parameters = ParseParameters(message);
		
		return new IRCMessage(prefix, command, parameters);
	}

	private static List<string> ParseParameters(string message)
	{
		int trailingIndex = message.IndexOf(':');

		List<string> parameters = message
			.Substring(0, trailingIndex == -1 ? message.Length : trailingIndex)
			.Split(' ')
			.Where(p => !string.IsNullOrEmpty(p))
			.ToList();

		if (trailingIndex != -1)
			parameters.Add(message.Substring(trailingIndex + 1));

		return parameters;
	}

	private static (string, string) ParseCommand(string message)
	{
		string[] parts = message.Split(' ');
		return parts.Length < 2 ? (parts[0], string.Empty) : (parts[0], message.Substring(message.IndexOf(' ') + 1));
	}

	private static (string, string) ParsePrefix(string message)
	{
		if (message.StartsWith(":"))
		{
			int endIndex = message.IndexOf(' ');
			return (message.Substring(1, endIndex - 1), message.Substring(endIndex + 1));
		}
		return (string.Empty, message);
	}
}