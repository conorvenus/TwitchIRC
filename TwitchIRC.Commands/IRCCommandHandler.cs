﻿using System.Reflection;
using TwitchIRC.Types;

namespace TwitchIRC.Commands;

public class IRCCommandHandler
{
	private readonly Dictionary<string, MethodInfo> _commands = new Dictionary<string, MethodInfo>();
	private readonly IRCClient _client;
	private string _prefix;

	public IRCCommandHandler(IRCClient client, string prefix = "!")
	{
		_client = client;
		_client.OnChatMessage += OnChatMessage;
		_prefix = prefix;
	}

	private void OnChatMessage(IRCChatMessage message)
	{
		if (!message.Content.StartsWith(_prefix)) return;

		MethodInfo? commandMethod = _commands.GetValueOrDefault(message.Content.Substring(_prefix.Length));
		if (commandMethod is null) return;

		IRCCommandModule? commandModule = (IRCCommandModule?)Activator.CreateInstance(commandMethod.DeclaringType);
		if (commandModule is null) return;

		commandModule.Context = new IRCContext(message, _client);
		commandMethod.Invoke(commandModule, null);
	}

	public IRCCommandHandler Register()
	{
		List<Type> commandModules = Assembly.GetCallingAssembly().GetTypes().Where(type => type.IsSubclassOf(typeof(IRCCommandModule))).ToList();
		foreach (Type commandModule in commandModules)
		{
			List<MethodInfo> commandMethods = commandModule.GetMethods().Where(method => method.CustomAttributes.Any(attribute => attribute.AttributeType == typeof(IRCCommand))).ToList();
			foreach (MethodInfo commandMethod in commandMethods)
			{
				IRCCommand commandAttribute = (IRCCommand)commandMethod.GetCustomAttributes(typeof(IRCCommand), false).First();
				_commands.Add(commandAttribute.CommandName, commandMethod);
			}
		}
		return this;
	}
}