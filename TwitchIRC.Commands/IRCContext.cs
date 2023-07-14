using TwitchIRC.Types;

namespace TwitchIRC.Commands;

public class IRCContext
{
    public IRCChatMessage Message { get; }
    public IRCClient Client { get; }

    public IRCContext(IRCChatMessage message, IRCClient client)
    {
        Message = message;
        Client = client;
    }
}