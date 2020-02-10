using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgWorker
{
    /// <summary>
    /// A background thread with an input queue.
    /// </summary>
    /// 
    public class WorkerThread
    {
        public const int MAX_Q_SIZE = 5;
        public bool ShouldStop { get; set; }

        private Queue<IWorkElement> inputQueue = new Queue<IWorkElement>();
        private Thread thread;
        private bool busy = false;
        Action<IWorkElement> CallBack;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="callBack">Called for each finished element</param>
        public WorkerThread(Action<IWorkElement> callBack)
        {
            CallBack = callBack;
            thread = new Thread(Run);
            thread.Start();
        }

        /// <summary>
        /// Call this when the application wants to exit.
        /// </summary>
        public void Stop()
        {
            //Signal thread to stop and wait for it.
            ShouldStop = true;
            lock (inputQueue)
            {
                Monitor.PulseAll(inputQueue);
            }
            thread.Join();
        }

        /// <summary>
        /// Get number of elements in the input queue.
        /// </summary>
        /// <returns>Number of elements in the input queue</returns>
        public int GetQueueSize()
        {
            lock(inputQueue)
            {
                int ret = inputQueue.Count;
                //If input queue is empty then return 1 if there is an element busy
                //This to show the progress bar better
                if (ret == 0 && busy)
                {
                    ret = 1;
                }
                return ret;
            }
        }

        /// <summary>
        /// Add item to the input work queue.
        /// </summary>
        /// <param name="elem">The element to be added to the queue.</param>
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

        /// <summary>
        /// Get an element out of the input queue.
        /// Blocks if the queue is empty.
        /// </summary>
        /// <returns>First element in the queue or null if the application wants to exit.</returns>
        private IWorkElement GetWork()
        {
            lock (inputQueue)
            {
                //Wait until the queue is not empty or the application wants to exit.
                while(inputQueue.Count == 0 && !ShouldStop)
                {
                    Monitor.Wait(inputQueue);
                }
                //If the queue is not empty then return it's first element.
                if (inputQueue.Count > 0)
                {
                    IWorkElement e = inputQueue.Dequeue();
                    return e;
                }
                //The queue is empty but we were signaled. The app must be wanting to exit.
                Debug.Assert(ShouldStop == true);
                return null;
            }
        }

        /// <summary>
        /// Thread routine (loop)
        /// </summary>
        private void Run()
        {
            while(!ShouldStop)
            {
                //Get first element from queue
                IWorkElement e = GetWork();
                //If null is returned then the app wants to exit.
                if (e == null)
                {
                    return;
                }
                //Handle the element. Do it's work and call the callback routine when done.
                busy = true;
                e.Execute();
                CallBack(e);
                busy = false;
            }
        }
    }
}
