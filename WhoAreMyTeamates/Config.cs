using System.ComponentModel;
using Exiled.API.Interfaces;

namespace WhoAreMyTeammates.Handlers
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin Enabled? - Accepts Bool (Def: true)")]
        public bool IsEnabled { get; set; } = true;

        [Description(
            "The Broadcast message that will alert the SCP Team to their teamates. Use {0} for the list of SCPs. (Custom Colours not accepted)")]
        public string WamtBroadcast { get; set; } =
            "<color=aqua>Welcome to the</color><color=red><b> SCP Team.</b></color><color=aqua> The following SCPs are on this team: </color><color=red>{0}</color>";

        [Description("Broadcast Time in Seconds - Accepts whole numbers >0 (Def: 10")]
        public ushort WamtBCTime { get; set; } = 10;

        [Description(
            "The Delay before the broadcast will be issued. Please ammend based on your servers use case incase you have a broadcast from another plugin. Accepts integers >0 (Def: 20)")]
        public int WamtBCDelay { get; set; } = 20;
    }

}
