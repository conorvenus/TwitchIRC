namespace TwitchIRC.Core;

internal interface IIRCNetworkWrapper
{
	public void Send(string message);

	public string Receive();
}