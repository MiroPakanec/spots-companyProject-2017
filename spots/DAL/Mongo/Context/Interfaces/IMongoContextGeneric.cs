using MongoDB.Driver;

namespace spots.DAL.Mongo.Context.Interfaces
{
    public interface IMongoContextGeneric<TEntity> where TEntity : class
    {
        IMongoCollection<TEntity> Collection { get; }
    }
}
