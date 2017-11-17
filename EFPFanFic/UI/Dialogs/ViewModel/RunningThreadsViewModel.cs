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
            _manager.ThreadAborted += _manager_ThreadAborted;

            RefreshThreadsList();
        }

        private void _manager_ThreadAborted(string threadName)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                RefreshThreadsList();
                MessageBox.Show(string.Format("Exportation of '{0}' aborted", threadName),"Information",MessageBoxButton.OK,MessageBoxImage.Information);
            });
        }

        private void _manager_ThreadCompleted()
        {
            Dispatcher.CurrentDispatcher.Invoke(() => RefreshThreadsList());
        }

        private void RefreshThreadsList()
        {
            if (!Application.Current.Dispatcher.CheckAccess())
            {
                Application.Current.Dispatcher.Invoke(() => RefreshThreadsList());
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

                        ThreadEntryViewModel vm = new ThreadEntryViewModel(threadId, tw.ThreadName, tw.StartTime);
                        vm.CloseThread += Vm_CloseThread;

                        _threads.Add(vm);
                    }
                }
            }
        }

        private void Vm_CloseThread(int threadId)
        {
            if (!Application.Current.Dispatcher.CheckAccess())
            {
                Application.Current.Dispatcher.Invoke(() => Vm_CloseThread(threadId));
            }
            else
            {
                _manager.KillThread(threadId);
                RefreshThreadsList();
            }
        }
    }
}
