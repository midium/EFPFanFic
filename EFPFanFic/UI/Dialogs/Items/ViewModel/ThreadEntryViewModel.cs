using EFPFanFic.UI.Dialogs.Items.Commands;
using Midium.Helpers.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace EFPFanFic.UI.Dialogs.Items.ViewModel
{
    public class ThreadEntryViewModel : ObservableObject
    {
        private DateTime _startTime;
        private string _startTimeString;
        private string _name;
        private long _id;
        private string _elapsed;

        private CloseThreadCommand _closeThreadCommand;
        private DispatcherTimer _timer;

        public event Action<int> CloseThread;

        public string StartTime { get =>_startTimeString; set { _startTimeString = value; OnPropertyChanged(); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(); } }
        public long Id { get => _id; set => _id = value; }
        public CloseThreadCommand CloseThreadCommand { get => _closeThreadCommand; }
        public DateTime StartTimeValue { get => _startTime; set { _startTime = value; OnPropertyChanged(); StartTime = value.ToLongTimeString(); } }
        public string Elapsed { get => _elapsed; set { _elapsed = value; OnPropertyChanged(); } }

        public ThreadEntryViewModel(int id, string name, DateTime startTime)
        {
            _id = id;
            _name = name;
            StartTimeValue = startTime;

            InitCommandsAndHandlers(true);
        }

        public ThreadEntryViewModel(int id, string name, string startTime, string elapsed)
        {
            _id = id;
            _name = name;
            _startTimeString = startTime;
            _elapsed = elapsed;
            InitCommandsAndHandlers(false);
        }

        ~ThreadEntryViewModel()
        {
            _timer?.Stop();
            _timer = null;
        }

        private void InitCommandsAndHandlers(bool initTicker)
        {
            _closeThreadCommand = new CloseThreadCommand();
            _closeThreadCommand.RunCloseThread += _RunCloseThread;

            if (initTicker)
            {
                _timer = new DispatcherTimer();
                _timer.Tick += _Tick;
                _timer.Interval = new TimeSpan(0, 0, 0, 1);
                _timer.Start();
            }

        }

        private void _Tick(object sender, EventArgs e)
        {
            if (_startTime == null || _startTime == DateTime.MinValue) return;

            TimeSpan result = DateTime.Now - _startTime;

            Elapsed = string.Format("{0}:{1}", (result.Hours * 60) + result.Minutes, result.Seconds);

        }

        private void _RunCloseThread(int threadId)
        {
            CloseThread?.Invoke(threadId);
        }
    }
}
