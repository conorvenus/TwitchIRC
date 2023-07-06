using System.Net.Sockets;
using System.Text;

namespace TwitchIRC;

public class IRCNetworkWrapper
{
	private TcpClient _tcpClient;
	private StreamReader _reader;
	private StreamWriter _writer;

	public IRCNetworkWrapper(string hostName, int hostPort)
	{
		_tcpClient = new TcpClient(hostName, hostPort);
		var networkStream = _tcpClient.GetStream();
		_reader = new StreamReader(networkStream, Encoding.ASCII);
		_writer = new StreamWriter(networkStream, Encoding.ASCII) { AutoFlush = true };
	}

	public void Send(string message) => _writer.WriteLine(message);

	public string Receive() => _reader.ReadLine() ?? string.Empty;
}