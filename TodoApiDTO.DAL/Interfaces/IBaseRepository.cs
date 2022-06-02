using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TodoApiDTO.DAL.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<long> Add(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);

        Task AddRange(IEnumerable<TEntity> entities);

        Task UpdateRange(IEnumerable<TEntity> entities);

        Task DeleteRange(IEnumerable<TEntity> entities);
        Task Save();

        Task<TEntity> GetById(long id);
        Task<List<TEntity>> GetList();

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression);
    }
}
