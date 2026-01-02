using DAL.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IBase<TEntity, TKey, TResult>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(TKey id);
        Task<TResult> Create(TEntity entity);
        Task<TResult> Update(TEntity entity, TKey id);
        Task<bool> Delete(TKey id);
    }
}
