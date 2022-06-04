
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using Cinema.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Cinema.Data.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        Task<IEnumerable<TEntity>> GetAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<bool> DeleteAsync(int id);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
