using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Pages.Commands
{
    public class ShowRunningThreadsCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action ShowThreads;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ShowThreads?.Invoke();
        }
    }
}
