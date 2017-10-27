using EFPFanFic.UI.Selectors.FanFicsSelector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Selectors.FanFicsSelector.Commands
{
    public class SaveAsPdfCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;
        public Action<FanFicItemViewModel> SaveAsPdf;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SaveAsPdf?.Invoke(parameter as FanFicItemViewModel);
        }
    }
}
