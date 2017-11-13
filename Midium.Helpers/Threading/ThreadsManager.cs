using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Midium.Helpers.Threading
{
    public class ThreadsManager
    {
        private Dictionary<int, ThreadWork> _threadList;
        private Thread _thread;

        public ThreadsManager()
        {
            _threadList = new Dictionary<int, ThreadWork>();
        }

        public Dictionary<int, ThreadWork> ThreadList { get => _threadList; set => _threadList = value; }

        public void StartNewThread(Action action)
        {
            ThreadStart ts = new ThreadStart(action);
            _thread = new Thread(ts);

            _threadList.Add(_thread.ManagedThreadId, new ThreadWork(DateTime.Now, _thread));

            _thread.Start();
        }

    }

    public class ThreadWork
    {
        private DateTime _startTime;
        private Thread _thread;

        public ThreadWork(DateTime startTime, Thread thread)
        {
            _startTime = startTime;
            _thread = thread;
        }
    }
}
