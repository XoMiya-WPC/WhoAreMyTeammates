using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using WhoAreMyTeammates.Handlers;
using Server = Exiled.Events.Handlers.Server;
using Player = Exiled.Events.Handlers.Player;

namespace WhoAreMyTeammates
{
    public class WhoAreMyTeammates : Plugin<Config>
    {
        public override string Name { get; } = "WhoAreMyTeamates?";
        public override string Author { get; } = "XoMiya-WPC";
        public override string Prefix { get; } = "Who_Are_My_Teamates";
        public override Version Version { get; } = new Version("2.0.0");
        public override PluginPriority Priority { get; } = PluginPriority.Low;
        private EventHandlers server;
        private EventHandlers player;

        public override void OnEnabled()
        {
            server = new EventHandlers(this);
            player = new EventHandlers(this);
            Server.RoundStarted += server.OnRoundStart;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= server.OnRoundStart;
            server = null;
            player = null;
        }
    }
}