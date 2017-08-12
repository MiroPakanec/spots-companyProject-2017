using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using MongoDB.Driver;
using spots.DAL.Mongo.Context.Interfaces;

namespace spots.DAL.Queries.Repositories.Core
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoContextGeneric<TEntity> MongoContext;

        internal Repository(IMongoContextGeneric<TEntity> mongoContext)
        {
            MongoContext = mongoContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            var filter = Builders<TEntity>.Filter.Empty;
            return MongoContext.Collection.Find(filter).ToList();
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return MongoContext.Collection.Find(predicate).First();
        }

        public int FindAndDelete(Expression<Func<TEntity, bool>> predicate)
        {
            return (int) MongoContext.Collection.DeleteOne(predicate).DeletedCount;
        }

        public void Add(TEntity entity)
        {
            MongoContext.Collection.InsertOne(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            MongoContext.Collection.InsertMany(entities);
        }
    }
}