using System.Threading;

namespace spots.DAL.Queries.AtomicWork
{
    public abstract class AtomicWork : IAtomicWork
    {
        private static readonly Mutex Mutex = new Mutex();

        public void Lock()
        {
            Mutex.WaitOne();
        }

        public void Unlock()
        {
            Mutex.ReleaseMutex();
        }

        public abstract string Desc { get; }
    }
}