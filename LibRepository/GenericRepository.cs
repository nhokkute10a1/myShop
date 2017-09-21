using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbContext context;
        public DbSet<T> dbset;
        public GenericRepository(DbContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public GenericRepository() { }
        public T GetById(int id)
        {
            return dbset.Find(id);
        }
        public IQueryable<T> GetAll()
        {
            return dbset.AsQueryable();
        }
        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Insert(T entity)
        {
            dbset.Add(entity);
        }
        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }
        public bool GetAny(Expression<Func<T, bool>> predicate)
        {
            return dbset.AsQueryable().Any(predicate);
        }
        public IEnumerable<T> ExcCommand(string obj, params object[] parameters)
        {
            return context.Database.SqlQuery<T>(obj, parameters);
        }
        public IEnumerable<TEntity> SQLQuery<TEntity>(string sql, params object[] parameters)
        {
            return context.Database.SqlQuery<TEntity>(sql, parameters);
        }
        public void ExcQuery(string sql, params object[] parameters)
        {
            context.Database.ExecuteSqlCommand(sql, parameters);
        }
        public T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return dbset.FirstOrDefault(predicate);
        }
    }
}
