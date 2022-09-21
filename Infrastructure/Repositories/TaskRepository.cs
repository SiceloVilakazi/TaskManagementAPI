using Task = Domain.Entities.Task;
using Infastructure.Repositories;
using Domain.DBContext;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Provides operations for database related actions
    /// </summary>
    public class TaskRepository : BaseRepository<Task>, ITaskRepository
    {
        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public TaskRepository(TaskManagementDBContext dBContext) : base(dBContext)
        {
        }
    }
}