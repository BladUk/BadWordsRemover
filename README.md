# BadWordsRemover
Removes bad words from player's nickname.

## How to install plugin?

Put BadWordsRemover.dll under the release tab into sm_plugins folder.


## Configs
`bwr_disable` Disable the plugin. Type - boolean. Default - `true`.

`bwr_broadcast: true` Enables the broadcast. Type - boolean. Default - `true`.

`bwr_broadcast_duration` Duration of broadcast. Type - integer. Default - `7`.

`bwr_broadcast_string` Text of broadcast. Type - string. Default - `<i>A bad word has been found in your nickname.\nIt will be replaced.</i>`.

`bwr_broadcast_monospaced` Is broadcast monospaced? Type - boolean. Default - `true`.

`bwr_badwords_dictionary_path` Path to the words dictionary. Type - string. Default - `Empty`

`bwr_replacer_mode` Mode of the replacer. Type - string. Default - `replace`. **(replace or remove)**

`bwr_replacer_word` The text to replace the bad word. Type - string. Default - `[REDACTED]`.
