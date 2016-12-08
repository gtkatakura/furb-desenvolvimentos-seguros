using MongoDB.Driver;
using Scutum.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scutum.Infra.MongoDB
{
    public abstract class RepositoryMongo<TModel>
        where TModel : class, IEntityWithID
    {

        protected IMongoClient client;
        protected IMongoDatabase database;
        protected IMongoCollection<TModel> collection;

        public RepositoryMongo()
        {
            var tableName = typeof(TModel).Name.ToLower();

            this.client = new MongoClient();
            this.database = this.client.GetDatabase("ScutumWebAPI");
            this.collection = this.database.GetCollection<TModel>(tableName);
        }

        public virtual TModel Find(int id)
        {
            return this.collection.Find(x => x.Id == id).FirstOrDefault();
        }

        public virtual void Save(TModel model)
        {
            this.collection.InsertOne(model);
        }

        public virtual void Update(TModel model)
        {
            this.collection.ReplaceOne(x => x.Id == model.Id, model);
        }

        public virtual void Remove(TModel model)
        {
            this.collection.DeleteOne(x => x.Id == model.Id);
        }
    }
}
