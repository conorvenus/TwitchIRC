using TwitchIRC.Types;

namespace TwitchIRC;

public abstract class IRCEventHandler
{
	public event Action<IRCMessage, string>? OnMessage;
	public event Action<IRCChatMessage>? OnChatMessage;
	public event Action? OnReady;

	public void HandleMessage(IRCMessage message, string rawMessage) => OnMessage?.Invoke(message, rawMessage);
	public void HandleChatMessage(IRCChatMessage chatMessage) => OnChatMessage?.Invoke(chatMessage);
	public void HandleReady() => OnReady?.Invoke();
}