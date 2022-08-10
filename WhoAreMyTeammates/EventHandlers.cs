// -----------------------------------------------------------------------
// <copyright file="EventHandlers.cs" company="XoMiya-WPC and TheUltiOne">
// Copyright (c) XoMiya-WPC and TheUltiOne. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace WhoAreMyTeammates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using MEC;
    using NorthwoodLib.Pools;
    using WhoAreMyTeammates.Models;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandlers
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandlers"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the plugin class.</param>
        public EventHandlers(Plugin plugin) => this.plugin = plugin;

        public void OnRoundStarted()
        {
            Timing.CallDelayed(plugin.Config.DelayTime, () =>
            {
                foreach (WamtBroadcast broadcast in plugin.Config.WamtBroadcasts)
                    RunBroadcast(broadcast);
            });
        }

        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            var CREV = ev;
            Timing.CallDelayed(1f, () =>
            {
                foreach (WamtBroadcast broadcast in plugin.Config.WamtBroadcasts)
                {
                    List<Player> players = Player.Get(broadcast.Team).ToList();
                    if (broadcast.ClassChangeIsEnabled)
                    {
                        if (players.Contains(ev.Player))
                            ChangeRoleBc(CREV, broadcast);
                    }
                }
            });
        }

        private void ChangeRoleBc(ChangingRoleEventArgs CREV, WamtBroadcast broadcast)
        {
            List<Player> players = Player.Get(broadcast.Team).ToList();
            if (broadcast.MaxPlayers > -1 && players.Count >= broadcast.MaxPlayers)
                return;
            if (players.Count == 1)
            {
                DisplayBroadcast(players[0], broadcast.AloneContents, broadcast.Time, broadcast.Type);
                return;
            }
            string contentsFormatted = broadcast.ChangeClassContents.Replace("%list%", GeneratePlayerList(players, broadcast));
            contentsFormatted = contentsFormatted.Replace("%count%", players.Count.ToString());
            DisplayBroadcast(CREV.Player, contentsFormatted, broadcast.Time, broadcast.Type);
        }

        private void RunBroadcast(WamtBroadcast broadcast)
        {
            if (!broadcast.IsEnabled)
                return;

            List<Player> players = Player.Get(broadcast.Team).ToList();
            if (broadcast.MaxPlayers > -1 && players.Count >= broadcast.MaxPlayers)
                return;

            if (players.Count == 1)
            {
                Timing.CallDelayed(broadcast.Delay, () => DisplayBroadcast(players[0], broadcast.AloneContents, broadcast.Time, broadcast.Type));
                return;
            }

            string contentsFormatted = broadcast.Contents.Replace("%list%", GeneratePlayerList(players, broadcast));
            contentsFormatted = contentsFormatted.Replace("%count%", players.Count.ToString());
            foreach (Player player in players)
                Timing.CallDelayed(broadcast.Delay, () => DisplayBroadcast(player, contentsFormatted, broadcast.Time, broadcast.Type));
        }

        private void DisplayBroadcast(Player player, string content, ushort duration, DisplayType displayType)
        {
            switch (displayType)
            {
                case DisplayType.Broadcast:
                    player.Broadcast(duration, content);
                    return;
                case DisplayType.Hint:
                    player.ShowHint(content, duration);
                    return;
                case DisplayType.ConsoleMessage:
                    player.SendConsoleMessage(content, "cyan");
                    return;
            }
        }

        private string GeneratePlayerList(IList<Player> players, WamtBroadcast broadcast)
        {
            StringBuilder stringBuilder = StringBuilderPool.Shared.Rent();
            if (!broadcast.Contents.Contains("%list%"))
                return string.Empty;

            int cutOff = players.Count - 1;
            for (int i = 0; i < players.Count; i++)
            {
                Player player = players[i];

                stringBuilder.Append(' ').Append(player.Nickname);
                if (player.IsScp)
                    stringBuilder.Append(' ').Append('(').Append(player.ReferenceHub.characterClassManager.CurRole.fullName).Append(')');

                if (i != cutOff)
                    stringBuilder.Append(", ");
            }

            stringBuilder.Append('.');
            return StringBuilderPool.Shared.ToStringReturn(stringBuilder).TrimStart();
        }
    }
}
