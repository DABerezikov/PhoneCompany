using System.Windows;
using PhoneCompany.UI.Commands.Base;

namespace PhoneCompany.UI.Commands
{
    internal class CloseWindowCommand : Command
    {
        private static Window GetWindow(object p) => p as Window ?? App.FocusedWindow ?? App.ActiveWindow;

        protected override bool CanExecute(object p) => GetWindow(p) != null;

        protected override void Execute(object p) => GetWindow(p)?.Close();
    }
}
