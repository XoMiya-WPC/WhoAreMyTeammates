using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Exiled.API.Interfaces;

namespace WhoAreMyTeammates
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin Enabled? - Accepts Bool (Def: true)")]
        public bool IsEnabled { get; set; } = true;

        [Description("Is Debugging Enabled? - Accepts Bool (Def: false)")]
        public bool EnableDebug { get; set; } = false;

        [Description("Preliminary Delay Time in Seconds - Accepts whole numbers (0 will disable preliminary delay)")]
        public float WamtPreliminaryDelayTime { get; set; } = 0;

        [Description("Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates")]
        public List<WamtBroadcast> WamtBroadcasts { get; set; } = new List<WamtBroadcast>()
        {
            new WamtBroadcast()
            {
                Team = Team.SCP,
                Contents =
                    "<color=aqua>Welcome to the</color><color=red><b> SCP Team.</b></color><color=aqua> The following SCPs are on this team: </color><color=red>%list%</color>",
                AloneContents = "<color=red>Attention - You are the <b>only</b> SCP This game. Good Luck.</color>",
                Delay = 20,
                MaxPlayers = -1,
                Type = 0,
                Time = 10,
                Enabled = true
            },
            new WamtBroadcast()
            {
                Team = Team.MTF,
                Contents =
                    "<color=aqua>Welcome to the</color><color=grey><b> MTF Team.</b></color><color=aqua> The following Guards are on this team: </color><color=grey>%list%</color>",
                AloneContents = "<color=grey>Attention - You are the <b>only</b> Facility Guard this game. Good Luck.</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = 0,
                Time = 10,
                Enabled = true
            },
            new WamtBroadcast()
            {
                Team = Team.RSC,
                Contents =
                    "<color=aqua>Welcome to the</color><color=yellow><b> Scientist Team.</b></color><color=aqua> These are your partners in science: </color><color=yellow>%list%</color>",
                AloneContents = "<color=yellow>Attention - You are the <b>only</b> Scientist this game. Good Luck.</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = 0,
                Time = 10,
                Enabled = true
            },
            new WamtBroadcast()
            {
                Team = Team.CDP,
                Contents =
                    "<color=aqua>Welcome to the</color><color=orange><b> Class D Team.</b></color><color=aqua> The following class Ds are on this team: </color><color=orange>%list%</color>",
                AloneContents = "<color=orange>Attention - You are the <b>only</b> Class D Personnel this game. Good Luck.</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = 0,
                Time = 10,
                Enabled = true
            },
            new WamtBroadcast()
            {
                Team = Team.CHI,
                Contents =
                    "<color=aqua>Welcome to the</color><color=green><b> Chaos Insurgency.</b></color><color=aqua> The following players are your comrades: </color><color=green>%list%</color>",
                AloneContents = "<color=green>Attention - You are the <b>only</b> Insurgent this game. Good Luck.</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = 0,
                Time = 10,
                Enabled = true
            }
        };
    }

    public class WamtBroadcast
    {
        public Team Team { get; set; }
        public string Contents { get; set; }
        public string AloneContents { get; set; }
        public int Delay { get; set; } = 3;
        public int MaxPlayers { get; set; } = -1;
        public int Type { get; set; } = 0;
        public ushort Time { get; set; } = 10;
        public bool Enabled { get; set; } = true;
    }
}