using System.Net.Sockets;
using System.Text;
using TwitchIRC.Core;
using TwitchIRC.Options;

namespace TwitchIRC;

internal class IRCNetworkWrapper : IIRCNetworkWrapper
{
	private TcpClient _tcpClient;
	private StreamReader _reader;
	private NetworkStream _stream;

	public IRCNetworkWrapper(IRCHostOptions hostOptions)
	{
		_tcpClient = new TcpClient(hostOptions.HostName, hostOptions.HostPort);
		_stream = _tcpClient.GetStream();
		_reader = new StreamReader(_stream, Encoding.UTF8);
	}

	public void Send(string message) 
	{
		byte[] bytes = Encoding.UTF8.GetBytes(message + "\r\n");
		_stream.Write(bytes, 0, bytes.Length);
	}

	public string Receive() => _reader.ReadLine() ?? string.Empty;
}