namespace TwitchIRC.Commands;

[AttributeUsage(AttributeTargets.Method)]
public sealed class IRCCommand : Attribute
{
    public string CommandName { get; }

    public IRCCommand(string commandName)
    {
        CommandName = commandName;
    }
}