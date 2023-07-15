using TwitchIRC.Types;

namespace TwitchIRC;

public abstract class IRCEventHandler
{
	public event Action<IRCMessage, string>? OnMessage;
	public event Action<IRCChatMessage>? OnChatMessage;
	public event Action<string, string>? OnUserJoin;
	public event Action<string, string>? OnUserPart;
    public event Action? OnReady;

	public void HandleMessage(IRCMessage message, string rawMessage) => OnMessage?.Invoke(message, rawMessage);
	public void HandleChatMessage(IRCChatMessage chatMessage) => OnChatMessage?.Invoke(chatMessage);
	public void HandleReady() => OnReady?.Invoke();
	public void HandleUserJoin(string user, string channel) => OnUserJoin?.Invoke(user, channel);
	public void HandleUserPart(string user, string channel) => OnUserPart?.Invoke(user, channel);
}