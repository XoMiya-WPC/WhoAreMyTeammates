# WhoAreMyTeammates?

<h1>Intro</h1>
A plugin for SCP: SL that shows the specified Team a list of their teammates on spawn.
Sends a broadcast out to the players on the team containing a list of their fellow players. For SCPs it will show a list of SCP numbers.

<h1>Requirements</h1>

This plugin requires [EXILED](https://github.com/Exiled-Team/EXILED/releases "Exiled Releases") `3.0.0`
This plugin **WILL NOT WORK** on previous versions
<h1>General Config</h1>

| Config  | Type | Def Value |
| ------------- | ------------- | ------------- |
| `is_enabled`  | Boolean  | true  |
| `enable_debug`  | Boolean  | false  |
| `wamt_b_c_time`  | Integer  | 10  |

* **is_enabled:** Defines if the plugin will be enabled or not. Only enter `true` or `false`.
* **enable_debug:** Defines if the plugin will print extra debugging messages in console. Only enter `true` or `false`.
* **wamt_b_c_time:** Global time for all broadcasts. This controls how long all of the broadcasts will be. Accepts `whole numbers`.

<h1>Broadcast Configs</h1>

| Config  | Type | Def Value |
| ------------- | ------------- | ------------- |
| `team` | Team | RSC, CHI, CDP, MTF, SCP |
| `contents`  | String  | See Below  |
| `alone_conents`  | String  | See Below  |
| `delay`  | Integer  | 3  |
| `max_players`  | Integer  | -1  |
| `enabled`  | Boolean  | true  |

* **team:** Choose from a list of the Teams: `RSC` - Scientists, `CHI` - Chaos Insurgency, `CDP` - Class D, `MTF` - Facility Guards, `SCP` - SCPs. Each team will define which role see the broadcast.
* **contents:** This is the broadcast that will be sent to players in that team if the playercount is greater than `1`.
* **alone_contents:** This is the broadcast that will be sent to players in that team if the playercount is less than `1`.
* **delay:** The delay in seconds from the round before sending the broadcast.
* **max_players:** The maximum number of players before the broadcast will not be sent. This is to prevent spam if you have lots of Class D for example. Set to `-1` to disable the limit.
* **enabled:** Defines if this teams broadcast is enabled.


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
This plugin was originally requested on the Exiled Discord Server.

V3.0.0 was made with assistance from The Ulti One

For help or issues Contact me on Discord @ XoMiya#6113 or join my [discord](https://discord.gg/DxWXw9jmXn "XoMiya's Kitchen")

![img](https://img.shields.io/github/downloads/XoMiya-WPC/WhoAreMyTeammates/total?style=for-the-badge)
