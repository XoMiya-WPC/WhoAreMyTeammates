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
            float PDelay = 0.5f;
            if (WhoAreMyTeammates.Instance.Config.WamtPreliminaryDelayTime != 0)
            {
                PDelay += WhoAreMyTeammates.Instance.Config.WamtPreliminaryDelayTime;
                Log.Debug($"WamtPreliminaryDelayTime is {WhoAreMyTeammates.Instance.Config.WamtPreliminaryDelayTime}, holding count for {PDelay} seconds...", WhoAreMyTeammates.Instance.Config.EnableDebug);
            }
            Timing.CallDelayed(PDelay, () =>
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
                if (wamt.Type == 0)
                {
                    Log.Debug("CallDelayed - Only one player is in this team.", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    Timing.CallDelayed(wamt.Delay, () => players.First().Broadcast(wamt.Time, wamt.AloneContents));
                    Log.Debug($"Sent Broadcast to {players.First().Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    return;
                }
                else if (wamt.Type == 1)
                {
                    Log.Debug("CallDelayed - Only one player is in this team.", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    Timing.CallDelayed(wamt.Delay, () => players.First().ShowHint(wamt.AloneContents, wamt.Time));
                    Log.Debug($"Sent Hint to {players.First().Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    return;
                  
                }
                else if (wamt.Type == 2)
                {
                    Log.Debug("CallDelayed - Only one player is in this team.", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    Timing.CallDelayed(wamt.Delay, () => players.First().SendConsoleMessage(wamt.AloneContents, "cyan"));
                    Log.Debug($"Sent Console Broadcast to {players.First().Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
                    return;
                    
                }
            }

            string names = string.Empty;
            string contentsFormatted = string.Empty;

            if (wamt.Contents.Contains("%list%"))
            {
                Log.Debug("%List% Detected Running Foreach", WhoAreMyTeammates.Instance.Config.EnableDebug);
                int i = 0;
                int playersCount = players.Count();
                foreach (Player name in players)
                {
                    i++;
                    if (name.Side == Side.Scp)
                    {
                        names += (i == playersCount ? "and " : "") + $"{ScpText[name.Role]}, ";
                        Log.Debug("Added SCP to names var", WhoAreMyTeammates.Instance.Config.EnableDebug);
                        continue;

                    }
                    names += (i == playersCount ? "and " : "") + $"{name.Nickname}, ";
                }
            }
            if (names.Length > 2) names = names.Substring(0, names.Length - 2);
            names += ".";
            contentsFormatted = wamt.Contents.Replace("%list%", names); 
            Log.Debug("Formated names to contentsFormatted (%list%)", WhoAreMyTeammates.Instance.Config.EnableDebug);
            contentsFormatted = contentsFormatted.Replace("%count%", playerCount.ToString());
            Log.Debug("Formated names to contentsFormatted (%count%)", WhoAreMyTeammates.Instance.Config.EnableDebug);
            if (wamt.Type == 0)
            {
                foreach (var player in players)
                {
                    Timing.CallDelayed(wamt.Delay, () => player.Broadcast(wamt.Time, contentsFormatted));
                    Log.Debug($"Sending Broadcast to {player.Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);

                }
            } 
            else if (wamt.Type == 1)
            {
                foreach (var player in players)
                {
                    Timing.CallDelayed(wamt.Delay, () => player.ShowHint(contentsFormatted, wamt.Time));
                    Log.Debug($"Sending Hint to {player.Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
                }

            }
            else if (wamt.Type == 2)
            {
                foreach (var player in players)
                {
                    Timing.CallDelayed(wamt.Delay, () => player.SendConsoleMessage(contentsFormatted, "cyan"));
                    Log.Debug($"Sending Console Broadcast to {player.Nickname}", WhoAreMyTeammates.Instance.Config.EnableDebug);
                }
            }
        }
    }
}
