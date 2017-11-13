using EFPFanFic.UI.Dialogs.Items.ViewModel;
using Midium.Helpers.Observable;
using Midium.Helpers.Threading;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace EFPFanFic.UI.Dialogs.ViewModel
{
    public class RunningThreadsViewModel : ObservableObject
    {
        private ThreadsManager _manager;
        private readonly object _lockObj = new object();
        private ObservableCollection<ThreadEntryViewModel> _threads = new ObservableCollection<ThreadEntryViewModel>();

        public ObservableCollection<ThreadEntryViewModel> Threads { get => _threads; set { _threads = value; OnPropertyChanged(); } }

        public RunningThreadsViewModel(ThreadsManager threadsManager)
        {
            _manager = threadsManager;
            _manager.ThreadCompleted += _manager_ThreadCompleted;

            InitiateThreadsList();
        }

        private void _manager_ThreadCompleted()
        {
            Dispatcher.CurrentDispatcher.Invoke(() => InitiateThreadsList());
        }

        private void InitiateThreadsList()
        {
            if (!Application.Current.Dispatcher.CheckAccess())
            {
                Application.Current.Dispatcher.Invoke(() => InitiateThreadsList());
            }
            else
            {

                lock (_lockObj)
                {
                    _threads.Clear();

                    foreach (int threadId in _manager.ThreadList.Keys)
                    {
                        ThreadWork tw = _manager.ThreadList[threadId] as ThreadWork;
                        if (tw == null) continue;

                        _threads.Add(new ThreadEntryViewModel(threadId, tw.ThreadName, tw.StartTime.ToShortTimeString()));
                    }
                }
            }
        }
    }
}
