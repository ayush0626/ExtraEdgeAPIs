using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExtraEdge.Repository.Interfaces
{
    public interface IMobileShopRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(int month);
        Task<IEnumerable<TEntity>> GetAllAsync(int fromMonth, int toMonth);
        Task<IEnumerable<TEntity>> GetAllAsync(DateTime fromMonth, DateTime toMonth);
        Task<IEnumerable<TEntity>> GetAllAsync(string brandName);
        Task<IEnumerable<TEntity>> GetAllAsync(string brandName, DateTime fromDate, DateTime toDate);
    }
}
