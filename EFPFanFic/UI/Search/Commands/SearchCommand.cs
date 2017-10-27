using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Search.Commands
{
    public class SearchCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action RunCommand;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            RunCommand?.Invoke();
        }
    }
}
