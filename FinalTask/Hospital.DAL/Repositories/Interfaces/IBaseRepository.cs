using Hospital.DAL.Entities;
using System.Collections.Generic;

namespace Hospital.DAL.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity:BaseEntity
    {
        //IReadOnlyList<TEntity> GetAll();
        TEntity GetById(int id);
        int Add(TEntity entity);
        bool Remove(int id);
        void SaveChanges();
    }
}
