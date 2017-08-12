namespace spots.DAL.Queries.AtomicWork
{
    public interface IAtomicWork
    {
        void Lock();
        void Unlock();

        string Desc { get; }
    }
}
