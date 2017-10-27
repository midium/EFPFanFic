using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFPFanFic.UI.Pages
{
    public class PagesHelper:ObservableObject
    {
        private UserControl _currentPageViewModel;
        private string _windowTitle;

        public UserControl CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                if (_windowTitle != value)
                {
                    _windowTitle = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
