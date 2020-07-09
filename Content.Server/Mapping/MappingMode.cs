using Content.Server.GameObjects;
using Content.Server.GameObjects.Components.Observer;
using Content.Server.Interfaces.GameTicking;
using Content.Server.Players;
using Robust.Server.Interfaces.Console;
using Robust.Server.Interfaces.Player;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.IoC;

namespace Content.Server.Mapping
{
    public class MappingMode : IClientCommand
    {
        public string Command => "mappingmode";
        public string Description => "Enters or exits mapping mode";
        public string Help => "mappingmode";
        public void Execute(IConsoleShell shell, IPlayerSession player, string[] args)
        {
            if (player == null)
            {
                shell.SendText((IPlayerSession) null, "Nah");
                return;
            }

            var mind = player.ContentData().Mind;

            var position = IoCManager.Resolve<IGameTicker>().GetObserverSpawnPoint();

            var entityManager = IoCManager.Resolve<IEntityManager>();
            var mapping = entityManager.SpawnEntity("MappingMob", position);
            mapping.Name = player.Name;

            if(player.AttachedEntity != null)
                mind.Visit(mapping);
            else
                mind.TransferTo(mapping);
        }
    }
}
