namespace TwitchIRC;

public abstract class IRCEventHandler
{
	public event Action<string>? OnMessage;
	public event Action? OnReady;

	public void HandleMessage(string message) => OnMessage?.Invoke(message);
	public void HandleReady() => OnReady?.Invoke();
}