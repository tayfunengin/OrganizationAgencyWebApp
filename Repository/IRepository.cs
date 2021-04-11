using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        string Insert(T entity);
        string Update(int id, T entity);
        string Delete(T entity);

        void SaveChanges();
        bool Any(Expression<Func<T, bool>> exp);
        List<T> GetDefault(Expression<Func<T, bool>> exp);
    }

}
