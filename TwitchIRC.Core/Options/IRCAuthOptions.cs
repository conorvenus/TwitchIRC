namespace TwitchIRC.Options;

internal class IRCAuthOptions
{
	private string _accessToken = string.Empty;

	public string AccessToken
	{
		get => _accessToken.StartsWith("oauth:") ? _accessToken : $"oauth:{_accessToken}";
		set => _accessToken = value;
	}

	public string? Username { get; set; }
}