using Robust.Client.CEF;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.CustomControls;
using Robust.Shared.Console;

namespace Content.Client
{
    public class Browse : IConsoleCommand
    {
        public string Command => "browse";
        public string Description => "a";
        public string Help => "a";
        public void Execute(IConsoleShell shell, string argStr, string[] args)
        {
            var window = new SS14Window();

            var browser = new BrowserControl();

            if (args.Length < 1)
                return;

            browser.MouseFilter = Control.MouseFilterMode.Stop;
            window.MouseFilter = Control.MouseFilterMode.Pass;
            window.Contents.AddChild(browser);

            browser.Browse(args[0]);

            window.Open();
        }
    }
}
