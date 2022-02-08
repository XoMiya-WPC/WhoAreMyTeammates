using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using CommandSystem;
using RemoteAdmin;
using Mirror;
using NorthwoodLib.Pools;
using Exiled.API.Features;

namespace WhoAreMyTeammates.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class WamtList : ICommand
    {
        public string Command { get; } = "WamtList";
        public string[] Aliases { get; } = { "WL" };
        public string Description { get; } = "Lists SCPs in the current round";
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            if (sender is PlayerCommandSender playerSender)
            {
                if (!playerSender.CharacterClassManager.IsAnyScp())

                {
                    response = "You must be an SCP to run this command!";
                    return false;
                }
                var scps = Player.Get(Team.SCP);
                var scpNames = new List<string>();
                foreach (var scp in scps)
                {
                    scpNames.Add(scp.ReferenceHub.characterClassManager.CurRole.fullName);
                    if (scp != scps.Last())
                        scpNames.Append(", ");
                    else
                        scpNames.Append(".");
                }
                playerSender.ReferenceHub.BroadcastMessage($"The Following SCPs are ingame: {scpNames}", 10);
                response = $"The Following SCPs are ingame: {scpNames}";
                return true;
            }
            else
            {
                var scps = Player.Get(Team.SCP);
                var scpNames = new List<string>();
                foreach (var scp in scps)
                {
                    scpNames.Add(scp.ReferenceHub.characterClassManager.CurRole.fullName);
                    if (scp != scps.Last())
                        scpNames.Append(", ");
                    else
                        scpNames.Append(".");
                }
                response = $"The Following SCPs are ingame: {scpNames}";
                return true;
            }


        }


    }
}