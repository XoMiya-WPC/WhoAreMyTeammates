using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;

namespace WhoAreMyTeammates.Handlers
{
    public class EventHandlers
    {
        public Dictionary<RoleType, string> ScpText = new Dictionary<RoleType, string>()
        {
            {RoleType.Scp049, "SCP-049"},
            {RoleType.Scp079, "SCP-079"},
            {RoleType.Scp096, "SCP-096"},
            {RoleType.Scp106, "SCP-106"},
            {RoleType.Scp173, "SCP-173"},
            {RoleType.Scp93953, "SCP-939-53"},
            {RoleType.Scp93989, "SCP-939-89"}
        };

        public void OnRoundStarted()
        {
            Timing.CallDelayed(0.5f, () =>
            {
                foreach (WamtBroadcast wamtBroadcast in WhoAreMyTeammates.Instance.Config.WamtBroadcasts)
                {
                    ShowBroadcast(wamtBroadcast);
                    Log.Debug("Called ShowBroadcast", WhoAreMyTeammates.Instance.Config.EnableDebug);
                }
            });
        }

        public void ShowBroadcast(WamtBroadcast wamt)
        {
            if (!wamt.Enabled)
            {
                Log.Debug("Class Broadcast Disabled - Skipping....", WhoAreMyTeammates.Instance.Config.EnableDebug);
                return;
            }     
            var players = Player.Get(wamt.Team);
            int playerCount = players.Count();
            //var MaxCap = false;
            if (wamt.MaxPlayers != -1)
            {
                Log.Debug("Attention - Detected Upper Limit to players - Moving to compare...", WhoAreMyTeammates.Instance.Config.EnableDebug);
                if (playerCount >= wamt.MaxPlayers)
                {
                    Log.Debug($"Max Players for {wamt.Team} ({wamt.MaxPlayers}) has been exceeded! Current count: {playerCount}. Skipping...", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    return;
                }
            }
                
            if (playerCount == 1) 
            {
                Log.Debug("CallDelayed - Only one player is in this team.", WhoAreMyTeammates.Instance.Config.EnableDebug);
                Timing.CallDelayed(wamt.Delay, () => players.First().Broadcast(WhoAreMyTeammates.Instance.Config.WamtBCTime, wamt.AloneContents));
                Log.Debug($"Sent Broadcast to {players.First().Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
                return;
            }

            string names = string.Empty;
            string contentsFormatted = string.Empty;

            if (wamt.Contents.Contains("%list%"))
            {
                Log.Debug("%List% Detected Running Foreach", WhoAreMyTeammates.Instance.Config.EnableDebug);
                foreach (Player name in players)
                {
                    if (name.Side == Side.Scp)
                    {
                        names += $"{ScpText[name.Role]}, ";
                        Log.Debug("Added SCP to names var", WhoAreMyTeammates.Instance.Config.EnableDebug);
                        continue;
                        
                    }
                    names += $"{name.Nickname}, ";
                }
            }
            contentsFormatted = wamt.Contents.Replace("%list%", names); 
            Log.Debug("Formated names to contentsFormatted (%list%)", WhoAreMyTeammates.Instance.Config.EnableDebug);
            contentsFormatted = contentsFormatted.Replace("%count%", playerCount.ToString());
            Log.Debug("Formated names to contentsFormatted (%count%)", WhoAreMyTeammates.Instance.Config.EnableDebug);
            foreach (var player in players)
            {
                Timing.CallDelayed(wamt.Delay, () => player.Broadcast(WhoAreMyTeammates.Instance.Config.WamtBCTime, contentsFormatted));
                Log.Debug($"Sending Broadcast to {player.Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
            } 
        }
    }
}