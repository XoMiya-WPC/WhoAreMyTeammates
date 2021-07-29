using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;
using GameCore;
using MEC;
using Log = Exiled.API.Features.Log;

namespace WhoAreMyTeammates.Handlers
{
    public class EventHandlers
    {
        private readonly WhoAreMyTeammates plugin;

        public EventHandlers(WhoAreMyTeammates plugin)
        {
            this.plugin = plugin;
        }

        public void OnRoundStart()
        {
            // Gets the List of SCPs on the SCP Team
            var scps = Player.Get(Team.SCP);
            var scpNames = new List<string>();
            //Moves through the list of SCPs and adds their Role to a string
            foreach (var scp in scps)
            {
                scpNames.Add(scp.Role.ToString());
            }

            //Adds a comma before each scp role
            var scpinfo = string.Join(", ", scpNames);
            //Removes Scp from the role name
            string scpinfos = scpinfo.Replace("Scp", "");
            //Concatenates the Substring and the Configured BC together using {0}
            string message = string.Format(plugin.Config.WamtBroadcast, scpinfos);
            //Defines strings for the 939s and adds a dash into their role names for ease on the eyes
            string s93953 = "93953";
            string s93989 = "93989";
            if (message.Contains(s93953))
            {
                message = message.Replace("93953", "939-53");
            }

            if (message.Contains(s93989))
            {
                message = message.Replace("93989", "939-89");
            }

            if (plugin.Config.IsBCDelayEnabled == true)
            {
                //Checks if SCP swap is installed and if so will apply a delay
                if (Exiled.Loader.Loader.Plugins.Any(p => p.Name == "ScpSwap" && p.Config.IsEnabled))
                {
                    ///Adds Delay into the broadcat time
                    Timing.CallDelayed(plugin.Config.WamtBCDelay, () =>
                    {
                        foreach (var scp in scps) ///Sends Broadcast to every player in the list of "scps"
                        {
                            scp.Broadcast(plugin.Config.WamtBCTime, message);
                            Log.Debug($"Successfully sent bc to players. The following SCPs are in game: {scpinfos}.");
                        }
                    });
                }
                else
                {
                    foreach (var scp in scps)
                    {
                        scp.Broadcast(plugin.Config.WamtBCTime, message);
                        Log.Debug($"Successfully sent bc to players. The following SCPs are in game: {scpinfos}.");
                    }
                }
            }
            else
            {
                foreach (var scp in scps)
                {
                    scp.Broadcast(plugin.Config.WamtBCTime, message);
                    Log.Debug($"Successfully sent bc to players. The following SCPs are in game: {scpinfos}.");
                }
            }
        }
    }
}


