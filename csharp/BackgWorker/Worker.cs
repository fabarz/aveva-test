using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgWorker
{
    public class Worker
    {
        public const int MAX_Q_SIZE = 5;
        public bool ShouldStop { get; set; }

        private Queue<IWorkElement> inputQueue = new Queue<IWorkElement>();
        private Thread thread;
        private bool busy = false;
        Action<IWorkElement> CallBack;

        public Worker(Action<IWorkElement> callBack)
        {
            CallBack = callBack;
            thread = new Thread(Run);
            thread.Start();
        }

        public void Stop()
        {
            ShouldStop = true;
            lock (inputQueue)
            {
                Monitor.PulseAll(inputQueue);
            }
            thread.Join();
        }

        public int GetQueueSize()
        {
            lock(inputQueue)
            {
                int ret = inputQueue.Count;
                if (ret == 0 && busy)
                {
                    ret = 1;
                }
                return ret;
            }
        }

        public void AddWork(IWorkElement elem)
        {
            lock (inputQueue)
            {
                if (inputQueue.Count >= MAX_Q_SIZE)
                {
                    elem.Error = new Exception("Queue is full.");
                    CallBack(elem);
                    return;
                }
                inputQueue.Enqueue(elem);
                Monitor.PulseAll(inputQueue);
            }
        }

        private IWorkElement GetWork()
        {
            lock (inputQueue)
            {
                while(inputQueue.Count == 0 && !ShouldStop)
                {
                    Monitor.Wait(inputQueue);
                }
                if (inputQueue.Count > 0)
                {
                    IWorkElement e = inputQueue.Dequeue();
                    return e;
                }
                Debug.Assert(ShouldStop == true);
                return null;
            }
        }

        private void Run()
        {
            while(!ShouldStop)
            {
                IWorkElement e = GetWork();
                if (e == null)
                {
                    return;
                }
                busy = true;
                e.Execute();
                CallBack(e);
                busy = false;
            }
        }
    }
}
