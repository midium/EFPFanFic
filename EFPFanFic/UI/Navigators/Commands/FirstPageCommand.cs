﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFPFanFic.UI.Navigators.Commands
{
    public class FirstPageCommand: ICommand
    {
        private Action _firstPage;

        public event EventHandler CanExecuteChanged;
        public Action FirstPage => _firstPage;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            FirstPage?.Invoke();
        }
    }
}
