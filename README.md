# WhoAreMyTeammates
<h1>Intro</h1>
A plugin for SCP: SL that shows the SCP Team a list of their teammates on spawn.
Sends a broadcast out to the SCP Team (all players who are SCPs) at the beginning of the game with a customizable message including a list of SCP numbers who are ingame.

<h1>Requirements</h1>
The latest release of this plugin requires EXILED 3.0.0
You can try other versions but do not blame me if it doesn't work :)
<h1>General Config</h1>

| Config  | Type | Def Value |
| ------------- | ------------- | ------------- |
| IsEnabled  | Boolean  | true  |
| EnableDebug  | Boolean  | false  |
| WamtBCTime  | Integer  | 10  |

<h1>Broadcast Configs</h1>

| Config  | Type | Def Value | Explanation |
| ------------- | ------------- | ------------- | ------------- |
| Team | Team | RSC, CHI, CDP, MTF, SCP | Each one represents the team - see below. Pick only one. |
| Contents  | String  | See Below  | The message that will be seen if you are on this team |
| AloneConents  | String  | See Below  | The message that will be seen if you are alone on a team |
| Delay  | Integer  | 3  | Delay in seconds from the round starting for the broadcast |
| MaxPlayers  | Integer  | -1  | A maximum player count. If the count is exceeded the broadcast will not show. -1 to disable |
| Enabled  | Boolean  | true  | Wether or not this teams broadcast is enabled |

<h2>Default Config Generated</h2>

```yaml
Who_Are_My_Teammates:
# Is the plugin Enabled? - Accepts Bool (Def: true)
  is_enabled: true
  # Is Debugging Enabled? - Accepts Bool (Def: false)
  enable_debug: false
  # Broadcast Time in Seconds - Accepts whole numbers >0 (Def: 10
  wamt_b_c_time: 10
  # Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates
  wamt_broadcasts:
  - team: SCP
    contents: '<color=aqua>Welcome to the</color><color=red><b> SCP Team.</b></color><color=aqua> The following SCPs are on this team: </color><color=red>%list%</color>'
    alone_contents: <color=red>Attention - You are the <b>only</b> SCP This game. Good Luck.</color>
    delay: 20
    max_players: -1
    enabled: true
  - team: MTF
    contents: '<color=aqua>Welcome to the</color><color=grey><b> MTF Team.</b></color><color=aqua> The following Guards are on this team: </color><color=grey>%list%</color>'
    alone_contents: <color=grey>Attention - You are the <b>only</b> Facility Guard this game. Good Luck.</color>
    delay: 3
    max_players: -1
    enabled: true
  - team: RSC
    contents: '<color=aqua>Welcome to the</color><color=yellow><b> Scientist Team.</b></color><color=aqua> These are your partners in science: </color><color=yellow>%list%</color>'
    alone_contents: <color=yellow>Attention - You are the <b>only</b> Scientist this game. Good Luck.</color>
    delay: 6
    max_players: -1
    enabled: true
  - team: CDP
    contents: '<color=aqua>Welcome to the</color><color=orange><b> Class D Team.</b></color><color=aqua> The following class Ds are on this team: </color><color=orange>%list%</color>'
    alone_contents: <color=orange>Attention - You are the <b>only</b> Class D Personnel this game. Good Luck.</color>
    delay: 6
    max_players: -1
    enabled: true
  - team: CHI
    contents: '<color=aqua>Welcome to the</color><color=green><b> Chaos Insurgency.</b></color><color=aqua> The following players are your comrades: </color><color=green>%list%</color>'
    alone_contents: <color=green>Attention - You are the <b>only</b> Insurgent this game. Good Luck.</color>
    delay: 6
    max_players: -1
    enabled: true
```

<h1>Info & Contact</h1>
This plugin was requested on the Exiled Discord Server.

For help or issues Contact me on Discord @ XoMiya#6113 or join my discord (https://discord.gg/DxWXw9jmXn)

![img](https://img.shields.io/github/downloads/XoMiya-WPC/WhoAreMyTeammates/total?style=for-the-badge)
