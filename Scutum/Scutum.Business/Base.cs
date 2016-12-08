using Scutum.Model.Interface;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Scutum.Business
{
    public abstract class Base<TData, TModel>
        where TData : Data.Base<TModel>, new()
        where TModel : class, IEntityWithID
    {
        protected TData data = new TData();

        public virtual IQueryable<TModel> Get()
        {
            return this.data.Get();
        }

        public virtual IQueryable<TModel> Get(int id)
        {
            return this.data.Get(id);
        }

        public virtual TModel Find(int id)
        {
            return this.data.Find(id);
        }

        public virtual bool Exists(int id)
        {
            return this.data.Exists(id);
        }

        public virtual int SaveChanges()
        {
            return this.data.SaveChanges();
        }

        public virtual int Save(TModel model)
        {
            return this.data.Save(model);
        }

        public virtual int Update(TModel model)
        {
            return this.data.Update(model);
        }

        public virtual int Remove(TModel model)
        {
            return this.data.Remove(model);
        }
    }
}