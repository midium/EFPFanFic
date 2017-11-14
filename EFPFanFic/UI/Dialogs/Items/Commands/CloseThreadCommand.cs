using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Dialogs.Items.Commands
{
    public class CloseThreadCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<int> RunCloseThread;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int threadID = Convert.ToInt32(parameter);
            RunCloseThread?.Invoke(threadID);
        }
    }
}
