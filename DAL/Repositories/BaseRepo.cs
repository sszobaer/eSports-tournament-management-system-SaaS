using DAL.Entities.Context;
using DAL.Entities.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    internal class BaseRepo<TEntity, TKey> : IBase<TEntity, TKey, bool>
        where TEntity : class
    {
        protected readonly UMSContext _context;
        public BaseRepo(UMSContext context)
        {
            _context = context;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> Get(TKey id)
        {
            var data = await _context.Set<TEntity>().FindAsync(id);
            if(id != null) return data;
            return null;

        }

        public virtual async Task<bool> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Delete(TKey id) 
        {
            var currentEntity = await Get(id);

            if(currentEntity == null) return false;

            _context.Set<TEntity>().Remove(currentEntity);
            return await _context.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(TEntity entity, TKey id)
        {
            var currentEntity = await Get(id);
            if (currentEntity == null) return false;
            _context.Entry(currentEntity).CurrentValues.SetValues(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
