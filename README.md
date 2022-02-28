# WhoAreMyTeammates?

<h1>Intro</h1>
A plugin for SCP: SL that shows the specified Team a list of their teammates on spawn.
Sends a broadcast out to the players on the team containing a list of their fellow players. For SCPs it will show a list of SCP numbers.

<h1>Requirements</h1>

This plugin requires [EXILED](https://github.com/Exiled-Team/EXILED/releases "Exiled Releases") `4.2.3`
The Latest Release marked as 5.0.0 will only work on this version
This plugin **WILL NOT WORK** on previous versions
<h1>General Config</h1>

| Config  | Type | Def Value |
| ------------- | ------------- | ------------- |
| `is_enabled`  | Boolean  | true  |
| `delay_time`  | Float  | 0  |

* **is_enabled:** Defines if the plugin will be enabled or not. Only enter `true` or `false`.
* **delay_time:** Global preliminary time to hold the plugin for. This controls how long the plugin will hold its calculations for. Most prominant uses are allowing other plugins to change classes at the beginning of the game. Accepts `whole numbers`.

<h1>Broadcast Configs</h1>

| Config  | Type | Def Value |
| ------------- | ------------- | ------------- |
| `team` | Team | RSC, CHI, CDP, MTF, SCP |
| `contents`  | String  | See Below  |
| `alone_conents`  | String  | See Below  |
| `delay`  | Integer  | 3  |
| `max_players`  | Integer  | -1  |
| `type`  | Integer  | 0  |
| `time`  | Ushort  | 10  |
| `enabled`  | Boolean  | true  |

* **team:** Choose from a list of the Teams: `RSC` - Scientists, `CHI` - Chaos Insurgency, `CDP` - Class D, `MTF` - Facility Guards, `SCP` - SCPs. Each team will define which role see the broadcast.
* **contents:** This is the message that will be sent to players in that team if the playercount is greater than `1`.
* **alone_contents:** This is the message that will be sent to players in that team if the playercount is less than `1`.
* **delay:** The delay in seconds from the round before sending the message once the information has been calculated. 
* **max_players:** The maximum number of players before the message will not be sent. This is to prevent spam if you have lots of Class D for example. Set to `-1` to disable the limit.
* **type:** The type of message that will be sent. `0` = **Hint**, `1` = **Console Message**, `2` = **Broadcast**.
* **time:** The time the message will last for. Does not apply to `type: 2`
* **enabled:** Defines if this teams message is enabled.


<h2>Default Config Generated</h2>

```yaml
Who_Are_My_Teammates:
# Is the plugin Enabled? - Accepts Bool (Def: true)
  is_enabled: true
  # Preliminary Delay Time in Seconds - Accepts whole numbers (0 will disable preliminary delay)
  delay_time: 0
  # Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates
  wamt_broadcasts:
  - team: SCP
    contents: '<color=aqua>Welcome to the</color><color=red><b> SCP Team.</b></color><color=aqua> The following SCPs are on this team: </color><color=red>%list%</color>'
    alone_contents: <color=red>Attention - You are the <b>only</b> SCP This game. Good Luck.</color>
    delay: 20
    max_players: -1
    type: 0
    time: 10
    enabled: true
  - team: MTF
    contents: '<color=aqua>Welcome to the</color><color=grey><b> MTF Team.</b></color><color=aqua> The following Guards are on this team: </color><color=grey>%list%</color>'
    alone_contents: <color=grey>Attention - You are the <b>only</b> Facility Guard this game. Good Luck.</color>
    delay: 3
    max_players: -1
    type: 0
    time: 10
    enabled: true
  - team: RSC
    contents: '<color=aqua>Welcome to the</color><color=yellow><b> Scientist Team.</b></color><color=aqua> These are your partners in science: </color><color=yellow>%list%</color>'
    alone_contents: <color=yellow>Attention - You are the <b>only</b> Scientist this game. Good Luck.</color>
    delay: 3
    max_players: -1
    type: 0
    time: 10
    enabled: true
  - team: CDP
    contents: '<color=aqua>Welcome to the</color><color=orange><b> Class D Team.</b></color><color=aqua> The following class Ds are on this team: </color><color=orange>%list%</color>'
    alone_contents: <color=orange>Attention - You are the <b>only</b> Class D Personnel this game. Good Luck.</color>
    delay: 3
    max_players: -1
    type: 0
    time: 10
    enabled: true
  - team: CHI
    contents: '<color=aqua>Welcome to the</color><color=green><b> Chaos Insurgency.</b></color><color=aqua> The following players are your comrades: </color><color=green>%list%</color>'
    alone_contents: <color=green>Attention - You are the <b>only</b> Insurgent this game. Good Luck.</color>
    delay: 3
    max_players: -1
    type: 0
    time: 10
    enabled: true
```

<h1>Info & Contact</h1>
This plugin was originally requested on the Exiled Discord Server.

This plugin was made with love by @TheUltiOne & Myself

For help or issues Contact me on Discord @ XoMiya#6113 or join my [discord](https://discord.gg/DxWXw9jmXn "XoMiya's Kitchen")

![img](https://img.shields.io/github/downloads/XoMiya-WPC/WhoAreMyTeammates/total?style=for-the-badge)
