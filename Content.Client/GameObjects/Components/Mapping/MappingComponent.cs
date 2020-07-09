using Content.Client.Interfaces.Chat;
using Content.Client.UserInterface;
using Content.Shared.GameObjects.Components.Mapping;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.Interfaces.GameObjects;
using Robust.Shared.IoC;

namespace Content.Client.GameObjects.Components.Mapping
{
    [RegisterComponent]
    public class MappingComponent : SharedMappingComponent
    {
        private MappingGui _gui;
        private bool _isAttached = false;

        [Dependency] private readonly IChatManager _chatManager = default!;
        [Dependency] private readonly IGameHud _gameHud = default!;

        public override void HandleMessage(ComponentMessage message, IComponent component)
        {
            base.HandleMessage(message, component);

            switch (message)
            {
                case PlayerAttachedMsg _:
                    if (_gui == null)
                    {
                        _gui = new MappingGui(this);
                    }
                    else
                    {
                        _gui.Orphan();
                    }

                    _chatManager.Visible = false;
                    _gameHud.CraftingButtonVisible = false;
                    _gameHud.HandsContainer.AddChild(_gui);
                    _isAttached = true;


                    break;

                case PlayerDetachedMsg _:
                    _chatManager.Visible = true;
                    _gui.Parent?.RemoveChild(_gui);
                    _isAttached = false;
                    break;
            }
        }
    }
}
