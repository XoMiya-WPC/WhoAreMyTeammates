// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="XoMiya-WPC and TheUltiOne">
// Copyright (c) XoMiya-WPC and TheUltiOne. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace WhoAreMyTeammates
{
    using System;
    using Exiled.API.Features;
    using Player = Exiled.Events.Handlers.Player;
    using Server = Exiled.Events.Handlers.Server;
    

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandlers eventHandlers;

        /// <inheritdoc />
        public override string Author { get; } = "XoMiya-WPC & TheUltiOne & Build";

        /// <inheritdoc />
        public override string Name { get; } = "WhoAreMyTeammates";

        /// <inheritdoc />
        public override string Prefix { get; } = "WhoAreMyTeammates";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override Version Version { get; } = new Version(4, 2, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            eventHandlers = new EventHandlers(this);
            Player.ChangingRole += eventHandlers.OnChangingRole;
            Server.RoundStarted += eventHandlers.OnRoundStarted;
            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            Player.ChangingRole -= eventHandlers.OnChangingRole;
            Server.RoundStarted -= eventHandlers.OnRoundStarted;
            
            eventHandlers = null;

            base.OnDisabled();
        }
    }
}