using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Pages.Commands
{
    public class ClosePanel: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action RunClosePanel;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RunClosePanel?.Invoke();
        }
    }
}
