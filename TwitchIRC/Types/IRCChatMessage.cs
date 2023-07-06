namespace TwitchIRC.Types;

public class IRCChatMessage
{
	public string Username { get; set; }
	public string Content { get; set; }

	public IRCChatMessage(string username, string content)
	{
		Username = username;
		Content = content;
	}
}