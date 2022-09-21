using Domain.DBContext;
using Domain.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infastructure.Repositories
{
    /// <summary>
    /// provides operations for databases
    /// </summary>
    /// <typeparam name="Tentity"></typeparam>
    public class BaseRepository<Tentity> : IAsyncRepository<Tentity> where Tentity : class
    {
        protected readonly DbSet<Tentity> _dbSet;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public BaseRepository(TaskManagementDBContext dBContext)
        {
            _dbSet = dBContext.Set<Tentity>();
        }
        /// <summary>
        /// Adds an of entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Tentity> AddAsync(Tentity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        /// <summary>
        /// Adds a range of entitites
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<Tentity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        /// <summary>
        /// Deletes a range of entities
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>

        public async Task DeleteAsync(Expression<Func<Tentity, bool>> expression)
        {
            var response = await _dbSet.Where(expression).ToListAsync();
            if (response == null)
                return;

            _dbSet.RemoveRange(response);
        }

        /// <summary>
        /// gets a list of all entities
        /// </summary>
        /// <returns></returns>
        public async Task<ICollection<Tentity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        /// <summary>
        /// gets a specific entity by a given expressions
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<Tentity> GetByExpressionAsync(Expression<Func<Tentity, bool>> expression)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity;
        }

        /// <summary>
        /// Gets a list of entities by a given expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<ICollection<Tentity>> ListByExpressionAsync(Expression<Func<Tentity, bool>> expression)
        {
            var entities = await _dbSet.Where(expression).ToListAsync();
            return entities;
        }

        /// <summary>
        /// updates an existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<Tentity> UpdateAsync(Tentity entity)
        {
            _dbSet.Update(entity);
            return await Task.FromResult(entity);
        }
    }
}
