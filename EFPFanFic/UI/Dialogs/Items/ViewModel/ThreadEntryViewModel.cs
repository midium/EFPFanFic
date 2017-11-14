using EFPFanFic.UI.Dialogs.Items.Commands;
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

        private CloseThreadCommand _closeThreadCommand;

        public event Action<int> CloseThread;

        public string StartTime { get => _startTime; set { _startTime = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public long Id { get => _id; set => _id = value; }
        public CloseThreadCommand CloseThreadCommand { get => _closeThreadCommand; }

        public ThreadEntryViewModel(int id, string name, string startTime)
        {
            _id = id;
            _name = name;
            _startTime = startTime;
            _closeThreadCommand = new CloseThreadCommand();
            _closeThreadCommand.RunCloseThread += _RunCloseThread;
        }

        private void _RunCloseThread(int threadId)
        {
            CloseThread?.Invoke(threadId);
        }
    }
}
