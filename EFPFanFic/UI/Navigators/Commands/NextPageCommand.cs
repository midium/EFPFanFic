using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Navigators.Commands
{
    public class NextPageCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action NextPage;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NextPage?.Invoke();
        }
    }
}
