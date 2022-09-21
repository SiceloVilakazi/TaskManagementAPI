using Domain.DBContext;
using Domain.Generic;

namespace Infastructure.UnitOfWork
{
    /// <summary>
    /// handles the unit of work functionality
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// declares the db context
        /// </summary>
        private readonly TaskManagementDBContext _dbContext;

        /// <summary>
        /// initializes the db context
        /// </summary>
        /// <param name="dBContext"></param>
        public UnitOfWork(TaskManagementDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        /// <summary>
        /// function to commit all the changes
        /// </summary>
        /// <returns></returns>
        public Task CommitAsync()
        {
            return _dbContext.SaveChangesAsync();
        }
    }
}
