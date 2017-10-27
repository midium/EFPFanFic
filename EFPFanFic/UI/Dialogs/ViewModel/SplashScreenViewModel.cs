using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Dialogs.ViewModel
{
    public class SplashScreenViewModel : ObservableObject
    {

        private string _version;
        private string _message;

        public string Version
        {
            get => string.Format("v.: {0}",_version);
            set { _version = value; OnPropertyChanged(); }
        }
        public string Message {
            get => _message;
            set { _message = value; OnPropertyChanged(); }
        }

        public SplashScreenViewModel(string version, string message)
        {
            _version = version;
            _message = message;
        }
    }
}
