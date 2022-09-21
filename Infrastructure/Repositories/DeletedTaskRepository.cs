
using Domain.DBContext;
using Domain.Entities;
using Domain.Interfaces;
using Infastructure.Repositories;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Provides operations for database related actions
    /// </summary>
    public class DeletedTaskRepository : BaseRepository<DeletedTask>, IDeletedTaskRepository
    {
        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public DeletedTaskRepository(TaskManagementDBContext dBContext) : base(dBContext)
        {
        }
    }
}
