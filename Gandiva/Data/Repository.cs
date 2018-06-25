using System;
using System.Data.Entity;
using System.Linq;
using Gandiva.Data.Entity;

namespace Gandiva.Data
{
    interface IRepository<TEntity> where TEntity : class
    {
        /* CRUD operation */
        TEntity Create(TEntity item);
        IQueryable<TEntity> Get();
        TEntity Get(int id);
        IQueryable<TEntity> Get(Func<TEntity, bool> predicate);
        void Update(TEntity item);
        void Delete(TEntity item);
    }

    abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly DbContext context;
        readonly IDbSet<TEntity> dbSet;

        protected Repository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public TEntity Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
			return item;
        }

        public IQueryable<TEntity> Get() { return dbSet.AsNoTracking(); }
        public TEntity Get(int id) { return dbSet.Find(id); }
        public IQueryable<TEntity> Get(Func<TEntity, bool> predicate) { return dbSet.AsNoTracking().Where(p => predicate(p)); }

        public void Update(TEntity item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            dbSet.Remove(item);
            context.SaveChanges();
        }
    }

    class UserRepository : Repository<User>
    {
        public UserRepository() : base(GandivaContext.Instance) { }
    }

    class TaskRepository : Repository<Task>
    {
        public TaskRepository() : base(GandivaContext.Instance) { }
    }

    class CommentRepository : Repository<Comment>
    {
        public CommentRepository() : base(GandivaContext.Instance) { }
    }
}