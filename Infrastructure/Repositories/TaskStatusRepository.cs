using TaskStatus = Domain.Entities.TaskStatus;
using Domain.DBContext;
using Infastructure.Repositories;
using Domain.Interfaces;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Provides operations for database related actions
    /// </summary>
    public class TaskStatusRepository : BaseRepository<TaskStatus>, ITaskStatusRepository
    {
        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public TaskStatusRepository(TaskManagementDBContext dBContext) : base(dBContext)
        {
        }
    }
}