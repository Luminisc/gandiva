using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Gandiva.Data
{
    interface IRepository<TEntity> where TEntity : class
    {
        /* CRUD operation */
        void Create(TEntity item);
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
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

        public void Create(TEntity item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> Get() { return dbSet.AsNoTracking().ToList(); }
        public TEntity Get(int id) { return dbSet.Find(id); }
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate) { return Get().Where(predicate).ToList(); }

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
        public UserRepository(DbContext context) : base(context) { }
    }

    class TaskRepository : Repository<Task>
    {
        public TaskRepository(DbContext context) : base(context) { }
    }

    class CommentRepository : Repository<Comment>
    {
        public CommentRepository(DbContext context) : base(context) { }
    }
}