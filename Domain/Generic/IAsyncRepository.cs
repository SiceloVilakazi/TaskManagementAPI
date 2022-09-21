using System.Linq.Expressions;

namespace Domain.Generic
{
    /// <summary>
    /// provides operations to query the database
    /// </summary>
    /// <typeparam name="Tentity"></typeparam>
    public interface IAsyncRepository<Tentity> where Tentity : class
    {
        /// <summary>
        /// Gets a list of all entities
        /// </summary>
        /// <returns></returns>
        Task<ICollection<Tentity>> GetAllAsync();

        /// <summary>
        /// Gets specific entity by a given expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<Tentity> GetByExpressionAsync(Expression<Func<Tentity, bool>> expression);

        /// <summary>
        /// gets an icollection of entities by a given expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<ICollection<Tentity>> ListByExpressionAsync(Expression<Func<Tentity, bool>> expression);

        /// <summary>
        /// Adds a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Tentity> AddAsync(Tentity entity);

        /// <summary>
        /// Adds a range of entities
        /// </summary>
        /// <param name="entities"></param>
        Task AddRangeAsync(IEnumerable<Tentity> entities);

        /// <summary>
        /// Updates an existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<Tentity> UpdateAsync(Tentity entity);

        /// <summary>
        /// Deletes an entity based on a given expression
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task DeleteAsync(Expression<Func<Tentity, bool>> expression);
    }
}
