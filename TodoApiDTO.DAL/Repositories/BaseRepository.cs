using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TodoApiDTO.DAL.Context;
using TodoApiDTO.DAL.Interfaces;

namespace TodoApiDTO.DAL.Repositories
{
    public class BaseRepository<TEntity>:IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected TodoContext _context;
        protected DbSet<TEntity> _repository;
        public BaseRepository(TodoContext context)
        {
            _context = context;
            _repository = context.Set<TEntity>();
        }

        public async Task<long> Add(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await Save();
            return entity.Id;
        }

        public async Task Update(TEntity entity)
        {
            _repository.Update(entity);
            await Save();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _repository.Remove(entity);
            await Save();
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await Save();
        }

        public async Task UpdateRange(IEnumerable<TEntity> entities)
        {
            _repository.UpdateRange(entities);
            await Save();
        }

        public virtual async Task DeleteRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            await Save();
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(long id)
        {
            return await _repository.FindAsync(id);
        }

        public async Task<List<TEntity>> GetList()
        {
            return await _repository.ToListAsync();
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> expression)
        {
            return  _repository.Where(expression).AsQueryable();
        }
    }
}
