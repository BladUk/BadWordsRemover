using Smod2;
using Smod2.EventHandlers;
using Smod2.Events;
using System.IO;

namespace BadWordsRemover
{
	internal class Events : IEventHandlerWaitingForPlayers, IEventHandlerNicknameSet
	{
		public bool broadcast;
		public int duration;
		public string broadcast_string;
		public bool isMonospaced;
		public string path;
		public string mode;
		public string replace_word;
		public string dictionarypath;
		private readonly Plugin plugin;
		public Events(Plugin plugin)
		{
			this.plugin = plugin;
		}

		public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {
			if (plugin.GetConfigBool("bwr_disable"))
			{
				plugin.PluginManager.DisablePlugin(plugin);
			}
			broadcast = plugin.GetConfigBool("bwr_broadcast");
			duration = plugin.GetConfigInt("bwr_broadcast_duration");
			broadcast_string = plugin.GetConfigString("bwr_broadcast_string");
			isMonospaced = plugin.GetConfigBool("bwr_broadcast_monospaced");
			mode = plugin.GetConfigString("bwr_replacer_mode");
			replace_word = plugin.GetConfigString("bwr_replacer_word");
			path = plugin.GetConfigString("bwr_badwords_dictionary_path");
			dictionarypath = path + FileManager.GetPathSeparator().ToString() + "BadWordsDictionary.txt";
			if (path.IsEmpty() || !path.IsEmpty() && !Directory.Exists(path) && !File.Exists(dictionarypath))
			{
				path = FileManager.GetAppFolder(true, true, "");
				plugin.Warn("Directory doesn't exists! Please, set value for config setting bwr_badwords_dictionary_path");
			}
			else if (Directory.Exists(path) && !File.Exists(dictionarypath))
			{
				plugin.Warn($"BadWordsDictionary.txt doesn't exists! Empty file BadWordsDictionarty.txt has been created in {dictionarypath}");
				File.Create(dictionarypath);
			}
		}
		public void OnNicknameSet(PlayerNicknameSetEvent ev)
        {
			if (ev.Player != null)
            {
				foreach (string badword in File.ReadAllLines(dictionarypath))
                {
					if(ev.Nickname.ToLower().Contains(badword.ToLower()))
                    {
						switch (mode.ToLower())
						{
							case "replace":
								int replaceIndex = ev.Nickname.ToLower().IndexOf(badword);
								ev.Nickname = ev.Nickname.Remove(replaceIndex, badword.Length);
								ev.Nickname = ev.Nickname.Insert(replaceIndex, replace_word);
								ev.Player.PersonalClearBroadcasts();
								ev.Player.PersonalBroadcast((uint)System.Convert.ToInt32(duration), broadcast_string, isMonospaced);
								break;
							case "remove":
								int removeIndex = ev.Nickname.ToLower().IndexOf(badword);
								ev.Nickname = ev.Nickname.Remove(removeIndex, badword.Length);
								ev.Player.PersonalClearBroadcasts();
								ev.Player.PersonalBroadcast((uint)System.Convert.ToInt32(duration), broadcast_string, isMonospaced);
								break;
							default:
								plugin.Warn("Config value bwr_replacer_mode is set incorrectly. Use replace or remove.");
								break;
						}
                    }
                }
            }
        }
	}
}