using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace LibRepository
{
    public interface IGenericRepository<T>
    {
        T GetById(int id);

        bool GetAny(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        IEnumerable<T> ExcCommand(string obj, params object[] parameters);
        IEnumerable<TEntity> SQLQuery<TEntity>(string sql, params object[] parameters);

        void ExcQuery(string sql, params object[] parameters);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}