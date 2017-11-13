using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPFanFic.UI.Dialogs.Items.ViewModel
{
    public class ThreadEntryViewModel : ObservableObject
    {
        private string _startTime;
        private string _name;
        private long _id;

        public string StartTime { get => _startTime; set { _startTime = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public long Id { get => _id; set => _id = value; }

        public ThreadEntryViewModel(int id, string name, string startTime)
        {
            _id = id;
            _name = name;
            _startTime = startTime;
        }
    }
}
