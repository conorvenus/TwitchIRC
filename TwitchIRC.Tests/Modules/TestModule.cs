using TwitchIRC.Commands;

namespace TwitchIRC.Tests.Modules;

internal class TestModule : IRCCommandModule
{
    [IRCCommand("ping")]
    public void Ping()
    {
        Reply("Thanks for your message!");
    }
}