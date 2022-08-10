// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="XoMiya-WPC and TheUltiOne">
// Copyright (c) XoMiya-WPC and TheUltiOne. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace WhoAreMyTeammates
{
    using Exiled.API.Interfaces;
    using System.Collections.Generic;
    using System.ComponentModel;
    using WhoAreMyTeammates.Models;

    /// <inheritdoc />
    public sealed class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the delay after the round starts before broadcasts will be displayed.
        /// </summary>
        [Description("The delay after the round starts before broadcasts will be displayed.")]
        public float DelayTime { get; set; } = 0;

        /// <summary>
        /// Gets or sets a collection of all the broadcasts to display.
        /// </summary>
        [Description("Sets broadcasts for each class. Use %list% for the player names/SCP names and %count% for number of teammates")]
        public List<WamtBroadcast> WamtBroadcasts { get; set; } = new List<WamtBroadcast>
        {
            new WamtBroadcast()
            {
                Team = Team.SCP,
                Contents = "Welcome to the<color=red><b> SCP Team.</b></color><color=#00ffff> The following SCPs are on this team: </color><color=red>%list%</color>",
                AloneContents = "<color=red>Attention - You are the <b>only</b> SCP This game. Good Luck.</color>",
                ChangeClassContents = "Welcome to the <color=red><b> SCP Team.</b></color><color=#00ffff> The following SCPs are on this team: </color><color=red>%list%</color>",
                Delay = 20,
                MaxPlayers = -1,
                Type = DisplayType.Hint,
                Time = 10,
                ClassChangeIsEnabled = true,
                IsEnabled = true,
            },
            new WamtBroadcast()
            {
                Team = Team.MTF,
                Contents = "Welcome to the<color=grey><b> MTF Team.</b></color><color=#00ffff> The following Guards are on this team: </color><color=grey>%list%</color>",
                AloneContents = "<color=grey>Attention - You are the <b>only</b> Facility Guard this game. Good Luck.</color>",
                ChangeClassContents = "Welcome to the<color=grey><b> MTF Team.</b></color><color=#00ffff> The following Guards are on this team: </color><color=grey>%list%</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = DisplayType.Hint,
                Time = 10,
                ClassChangeIsEnabled = true,
                IsEnabled = true,
            },
            new WamtBroadcast()
            {
                Team = Team.RSC,
                Contents = "Welcome to the<color=yellow><b> Scientist Team.</b></color><color=#00ffff> These are your partners in science: </color><color=yellow>%list%</color>",
                AloneContents = "<color=yellow>Attention - You are the <b>only</b> Scientist this game. Good Luck.</color>",
                ChangeClassContents = "Welcome to the<color=yellow><b> Scientist Team.</b></color><color=#00ffff> These are your partners in science: </color><color=yellow>%list%</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = DisplayType.Hint,
                Time = 10,
                ClassChangeIsEnabled = true,
                IsEnabled = true,
            },
            new WamtBroadcast()
            {
                Team = Team.CDP,
                Contents = "Welcome to the<color=orange><b> Class D Team.</b></color> The following class Ds are on this team: <color=orange>%list%</color>",
                AloneContents = "<color=orange>Attention - You are the <b>only</b> Class D Personnel this game. Good Luck.</color>",
                ChangeClassContents = "Welcome to the<color=orange><b> Class D Team.</b></color> The following class Ds are on this team: <color=orange>%list%</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = DisplayType.Hint,
                Time = 10,
                ClassChangeIsEnabled = true,
                IsEnabled = true,
            },
            new WamtBroadcast
            {
                Team = Team.CHI,
                Contents = "Welcome to the<color=green><b> Chaos Insurgency.</b></color> The following players are your comrades: <color=green>%list%</color>",
                AloneContents = "<color=green>Attention - You are the <b>only</b> Insurgent this game. Good Luck.</color>",
                ChangeClassContents = "Welcome to the<color=green><b> Chaos Insurgency.</b></color> The following players are your comrades: <color=green>%list%</color>",
                Delay = 3,
                MaxPlayers = -1,
                Type = DisplayType.Hint,
                Time = 10,
                ClassChangeIsEnabled = true,
                IsEnabled = true,
            },
        };
    }
}