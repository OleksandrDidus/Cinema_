using Cinema.Data;
using Cinema.Data.Models;
using Cinema.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cinema.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly CinemaContext _context;

        public GenericRepository(CinemaContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var added = await _context.Set<TEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            var navigationProps = added.CurrentValues.EntityType.GetDeclaredNavigations();

            if (navigationProps != null)
            {
                foreach (var prop in navigationProps)
                {
                    // load all navigations
                    await added.Navigation(prop.Name).LoadAsync();
                }
            }

            // return added entity
            return entity;  
        }

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (include != null)
            {
                query = include(query);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var exist = await _context.Set<TEntity>().FindAsync(id);

            if (exist == null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(exist);
            await _context.SaveChangesAsync();
            return true;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var exist = await _context.Set<TEntity>()
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (exist == null)
            {
                return null;
            }

            await _context.Set<TEntity>().Update(entity).ReloadAsync();
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
