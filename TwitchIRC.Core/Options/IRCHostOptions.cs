namespace TwitchIRC.Options;

internal class IRCHostOptions
{
	public string HostName { get; set; }
	public ushort HostPort { get; set; }

	public IRCHostOptions(string hostName, ushort hostPort)
	{
		HostName = hostName;
		HostPort = hostPort;
	}
}