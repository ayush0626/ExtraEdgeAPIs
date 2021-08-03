using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtraEdge.Models;

namespace ExtraEdge.Repository.Interfaces
{
    public interface IMobileCRUDRepository<TEntity>
    {
        Task<TEntity> GetAsync(long id);
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity dbEntity, TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
    }
}
