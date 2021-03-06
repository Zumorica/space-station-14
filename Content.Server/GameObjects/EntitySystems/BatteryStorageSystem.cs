﻿using Content.Server.GameObjects.Components.Power.PowerNetComponents;
using JetBrains.Annotations;
using Robust.Server.Interfaces.Timing;
using Robust.Shared.GameObjects.Systems;
using Robust.Shared.IoC;

namespace Content.Server.GameObjects.EntitySystems
{
    [UsedImplicitly]
    internal sealed class BatteryStorageSystem : EntitySystem
    {
        public override void Update(float frameTime)
        {
            foreach (var comp in ComponentManager.EntityQuery<BatteryStorageComponent>(false))
            {
                comp.Update(frameTime);
            }
        }
    }
}
