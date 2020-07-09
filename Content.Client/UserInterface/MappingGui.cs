using Content.Client.GameObjects.Components.Mapping;
using Robust.Client.UserInterface;

namespace Content.Client.UserInterface
{
    public class MappingGui : Control
    {
        private MappingComponent _owner;

        public MappingGui(MappingComponent owner)
        {
            _owner = owner;
        }
    }
}
