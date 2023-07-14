namespace TwitchIRC.Commands;

public abstract class IRCCommandModule
{
    public IRCContext Context { get; set; }

    public void Reply(string message) => Context.Client.Send($"PRIVMSG #{Context.Message.Channel} :{message}");
}