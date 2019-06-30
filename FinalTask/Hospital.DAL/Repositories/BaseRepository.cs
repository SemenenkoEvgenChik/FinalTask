using Hospital.DAL.Entities;
using Hospital.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Hospital.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly HospitalContext _context;

        public BaseRepository(HospitalContext context)
        {
            _context = context;
        }

        public int Add(TEntity entity)
        {

            entity = _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Where(x => x.Id == id).SingleOrDefault();
        }

        public bool Remove(int id)
        {
            var entity = GetById(id);
            if (entity is null)
            {
                throw new Exception("Sorry id == null. You mistake");
            }
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();

            return true;
        }
        public void SaveChanges()
        {
            SaveChanges();
        }


    }
}
