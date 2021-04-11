using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        string result = null;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Any(exp);
        }

        public string Delete(T entity)
        {
            try
            {
                if (entity!=null)
                {
                    _context.Set<T>().Remove(entity);
                    _context.SaveChanges();
                    result = "Deletion has been completed";
                }
                else
                {

                    result = "entity can not be empty";
                }
                

            }
            catch (Exception ex)
            {

                result = ex.Message;
              
            }
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().AsEnumerable();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp).ToList();
        }

        public string Insert(T entity)
        {
            try
            {
                if (entity!= null)
                {
                    _context.Set<T>().Add(entity);
                    _context.SaveChanges();
                    result = "Insert has been completed";
                }
                else
                {
                    result = "entity can not be empty";
                }
                
               
            }
            catch (Exception ex )
            {

                result = ex.Message;
            }
            return result;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public string Update(int id, T entity)
        {
            var update = _context.Set<T>().Find(id);
            try
            {
                if (update != null)
                {
                    _context.Entry(update).CurrentValues.SetValues(entity);

                    //_context.Set<T>().Update(update);
                    _context.SaveChanges();
                    result = $"ID {update.ID} has been updated";
                }
                else
                {
                    result = "entity can not be empty";
                }
            }
            catch (Exception ex)
            {

                result = ex.Message;
            }
            return result;
        }
    }
}
