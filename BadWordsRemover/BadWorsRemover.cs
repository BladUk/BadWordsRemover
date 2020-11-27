using Smod2;
using Smod2.Attributes;
using Smod2.Config;
using System;

namespace BadWordsRemover
{
	[PluginDetails(
		author = "[RUS]BladUk",
		name = "BadWordsRemover",
		description = "Removes bad words from player's nickname.",
		id = "bladuk.badwordsremover",
		version = "1.0.0",
		SmodMajor = 3,
		SmodMinor = 9,
		SmodRevision = 7
		)]
	class BadWordsRemover : Plugin
	{
		public override void OnDisable()
		{
			this.Info($"Plugin {this.Details.name} has been disabled.");
		}

		public override void OnEnable()
		{
			this.Info($"Plugin {this.Details.name} has been enabled.");
		}

		public override void Register()
		{
			this.AddEventHandlers(new Events(this));

			this.AddConfig(new ConfigSetting("bwr_disable", false, true, "Is BadWordsRemover plugin disabled?"));
			this.AddConfig(new ConfigSetting("bwr_broadcast", true, true, "Whether to notify players about the word found in their nickname"));
			this.AddConfig(new ConfigSetting("bwr_broadcast_duration", 7, true, "Duration of broadcast"));
			this.AddConfig(new ConfigSetting("bwr_broadcast_string", "<i>A bad word has been found in your nickname.\nIt will be replaced.</i>", true, "Broadcast text"));
			this.AddConfig(new ConfigSetting("bwr_broadcast_monospaced", true, true, "Broadcast flag"));
			this.AddConfig(new ConfigSetting("bwr_badwords_dictionary_path", String.Empty, true, "Path to the words dictionary"));
			this.AddConfig(new ConfigSetting("bwr_replacer_mode", "replace", true, "Replacer mode"));
			this.AddConfig(new ConfigSetting("bwr_replacer_word", "[REDACTED]", true, "Replacer word"));
		}
	}
}