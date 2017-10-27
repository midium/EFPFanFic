using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Navigators.Commands
{
    public class LastPageCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action LastPage;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            LastPage?.Invoke();
        }
    }
}
