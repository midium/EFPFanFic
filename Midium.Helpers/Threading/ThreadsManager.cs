using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace Midium.Helpers.Threading
{
    public class ThreadsManager
    {
        private Dictionary<int, ThreadWork> _threadList;
        private Thread _thread;
        private readonly object _lockObj = new object();
        public event Action ThreadCompleted;
        public event Action<string> ThreadAborted;

        public ThreadsManager()
        {
            _threadList = new Dictionary<int, ThreadWork>();
        }

        public Dictionary<int, ThreadWork> ThreadList { get => _threadList; set => _threadList = value; }

        public void StartNewThread(Action action, string threadName)
        {
            _thread = new Thread(() => RunAction(action, _thread.ManagedThreadId));

            _threadList.Add(_thread.ManagedThreadId, new ThreadWork(DateTime.Now, threadName, _thread));

            _thread.Start();
        }

        public void RunAction(Action action, int threadId)
        {
            try
            {
                Dispatcher.CurrentDispatcher.Invoke(action);
            }
            finally
            {
                Dispatcher.CurrentDispatcher.Invoke(() => ThreadFinished(threadId));
            }
        }

        private void ThreadFinished(int threadId)
        {
            lock (_lockObj)
            {
                if (_threadList != null && _threadList.ContainsKey(threadId))
                {
                    _threadList.Remove(threadId);
                    ThreadCompleted?.Invoke();
                }
            }
        }

        public void KillThread(int threadId)
        {
            lock (_lockObj)
            {
                if (_threadList != null && _threadList.ContainsKey(threadId))
                {
                    string threadName = _threadList[threadId].ThreadName;
                    _threadList[threadId].Thread.Abort();
                    _threadList.Remove(threadId);
                    ThreadAborted?.Invoke(threadName);
                } else
                {
                    MessageBox.Show("Unable to find the specified thread","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
        }
    }

    public class ThreadWork
    {
        private DateTime _startTime;
        private string _threadName;
        private Thread _thread;

        public ThreadWork(DateTime startTime, string threadName, Thread thread)
        {
            _startTime = startTime;
            _threadName = threadName;
            _thread = thread;
        }

        public DateTime StartTime { get => _startTime; set => _startTime = value; }
        public Thread Thread { get => _thread; set => _thread = value; }
        public string ThreadName { get => _threadName; set => _threadName = value; }
    }
}
