using Task = Domain.Entities.Task;
using Domain.Generic;

namespace Domain.Interfaces
{
    /// <summary>
    /// Task repository interface
    /// </summary>
    public interface ITaskRepository : IAsyncRepository<Task>
    {
    }
}
