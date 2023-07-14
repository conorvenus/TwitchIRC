namespace TwitchIRC.Types;

public class IRCChatMessage
{
	public string Username { get; set; }
	public string Channel { get; set; }
	public string Content { get; set; }

	public IRCChatMessage(string username, string channel, string content)
	{
		Username = username;
		Channel = channel;
		Content = content;
	}
}