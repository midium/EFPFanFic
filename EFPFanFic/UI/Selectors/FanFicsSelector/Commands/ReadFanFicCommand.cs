using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Selectors.FanFicsSelector.Commands
{
    public class ReadFanFicCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<FanFicItemViewModel> ReadFanFic;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ReadFanFic?.Invoke(parameter as FanFicItemViewModel);
        }
    }
}
