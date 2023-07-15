namespace TwitchIRC.Types;

public class IRCMessage
{
    public string Prefix { get; set; }
    public string Command { get; set; }
    public List<string> Parameters { get; set; }

    public IRCMessage(string prefix, string command, List<string> parameters)
	{
		Prefix = prefix;
		Command = command;
		Parameters = parameters;
	}
}