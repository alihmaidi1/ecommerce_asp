using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce_shared.Repository.interfaces
{
    public interface IgenericRepository<T> where T : class
    {

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<List<T>> GetAllasync();

        Task<T> GetByIdAsync(Guid id);
        void Commit();
        void Rollback();
        
        IDbContextTransaction BeginTransaction();


        IQueryable<T> GetTableAsNoTracking();
        IQueryable<T> GetTableAsTracking();






    }
}
