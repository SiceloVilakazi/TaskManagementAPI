using Domain.Generic;
using TaskStatus = Domain.Entities.TaskStatus;

namespace Domain.Interfaces
{
    /// <summary>
    /// Task status repository interface
    /// </summary>
    public interface ITaskStatusRepository  : IAsyncRepository<TaskStatus>
    {
    }
}
