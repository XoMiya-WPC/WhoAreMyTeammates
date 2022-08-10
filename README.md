# WhoAreMyTeammates?

![img](https://img.shields.io/github/downloads/XoMiya-WPC/WhoAreMyTeammates/total?style=for-the-badge)

<h1>Intro</h1>
A plugin for SCP: SL that shows the specified Team a list of their teammates on spawn.
Sends a broadcast out to the players on the team containing a list of their fellow players. For SCPs it will show a list of players with their SCP number in parenthesis. In addition there is the option for players to be notified on class change who is in their team.

<h1>Requirements</h1>

This plugin requires [EXILED](https://github.com/Exiled-Team/EXILED/releases "Exiled Releases") `5.0.0`
The Latest Release marked as 5.3.0 will only work on this version
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
| `is_enabled`  | Boolean  | true  |
| `class_change_is_enabled`  | Boolean  | true  |
| `team` | Team | RSC, CHI, CDP, MTF, SCP |
| `contents`  | String  | See Below  |
| `alone_conents`  | String  | See Below  |
| `change_class_contents`  | String  | See Below  |
| `delay`  | Integer  | 3  |
| `max_players`  | Integer  | -1  |
| `type`  | Enum  | Hint  |
| `time`  | Ushort  | 10  |

* **is_enabled:** Defines if this teams message is enabled.
* **class_change_is_enabled:** Defines if this teams class change alert function is enabled.
* **team:** Choose from a list of the Teams: `RSC` - Scientists, `CHI` - Chaos Insurgency, `CDP` - Class D, `MTF` - Facility Guards, `SCP` - SCPs. Each team will define which role see the broadcast.
* **contents:** This is the message that will be sent to players in that team if the playercount is greater than `1`.
* **alone_contents:** This is the message that will be sent to players in that team if the playercount is less than `1`.
* **change_class_contents:** This is the message that will be sent to players in that team if the palyercount is greater than `1`.
* **delay:** The delay in seconds from the round before sending the message once the information has been calculated. 
* **max_players:** The maximum number of players before the message will not be sent. This is to prevent spam if you have lots of Class D for example. Set to `-1` to disable the limit.
* **type:** The type of message that will be sent. `Hint`, `ConsoleMessage`, `Broadcast`.
* **time:** The time the message will last for. Does not apply to `ConsoleMessage`.


<h1>Info & Contact</h1>
This plugin was originally requested on the Exiled Discord Server.

This plugin was made with love by @TheUltiOne & Myself

For help or issues Contact me on Discord @ XoMiya#6113 or join my [discord](https://discord.gg/js4W9M5Csq "Miya's Kitchen")


<h2>Default Config Generated</h2>

```yaml
WhoAreMyTeammates:
  is_enabled: true
  # The delay after the round starts before broadcasts will be displayed.
  delay_time: 0
  # Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates
  wamt_broadcasts:
  - is_enabled: true
    class_change_is_enabled: true
    team: SCP
    contents: 'Welcome to the<color=red><b> SCP Team.</b></color><color=aqua> The following SCPs are on this team: </color><color=red>%list%</color>'
    alone_contents: <color=red>Attention - You are the <b>only</b> SCP This game. Good Luck.</color>
    change_class_contents: 'Welcome to the <color=red><b> SCP Team.</b></color><color=aqua> The following SCPs are on this team: </color><color=red>%list%</color>'
    delay: 20
    max_players: -1
    type: Hint
    time: 10
  - is_enabled: true
    class_change_is_enabled: true
    team: MTF
    contents: 'Welcome to the<color=grey><b> MTF Team.</b></color><color=aqua> The following Guards are on this team: </color><color=grey>%list%</color>'
    alone_contents: <color=grey>Attention - You are the <b>only</b> Facility Guard this game. Good Luck.</color>
    change_class_contents: 'Welcome to the<color=grey><b> MTF Team.</b></color><color=aqua> The following Guards are on this team: </color><color=grey>%list%</color>'
    delay: 3
    max_players: -1
    type: Hint
    time: 10
  - is_enabled: true
    class_change_is_enabled: true
    team: RSC
    contents: 'Welcome to the<color=yellow><b> Scientist Team.</b></color><color=aqua> These are your partners in science: </color><color=yellow>%list%</color>'
    alone_contents: <color=yellow>Attention - You are the <b>only</b> Scientist this game. Good Luck.</color>
    change_class_contents: 'Welcome to the<color=yellow><b> Scientist Team.</b></color><color=aqua> These are your partners in science: </color><color=yellow>%list%</color>'
    delay: 3
    max_players: -1
    type: Hint
    time: 10
  - is_enabled: true
    class_change_is_enabled: true
    team: CDP
    contents: 'Welcome to the<color=orange><b> Class D Team.</b></color> The following class Ds are on this team: <color=orange>%list%</color>'
    alone_contents: <color=orange>Attention - You are the <b>only</b> Class D Personnel this game. Good Luck.</color>
    change_class_contents: 'Welcome to the<color=orange><b> Class D Team.</b></color> The following class Ds are on this team: <color=orange>%list%</color>'
    delay: 3
    max_players: -1
    type: Hint
    time: 10
  - is_enabled: true
    class_change_is_enabled: true
    team: CHI
    contents: 'Welcome to the<color=green><b> Chaos Insurgency.</b></color> The following players are your comrades: <color=green>%list%</color>'
    alone_contents: <color=green>Attention - You are the <b>only</b> Insurgent this game. Good Luck.</color>
    change_class_contents: 'Welcome to the<color=green><b> Chaos Insurgency.</b></color> The following players are your comrades: <color=green>%list%</color>'
    delay: 3
    max_players: -1
    type: Hint
    time: 10
```

