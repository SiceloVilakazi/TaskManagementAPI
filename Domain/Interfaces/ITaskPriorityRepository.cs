using Domain.Entities;
using Domain.Generic;

namespace Domain.Interfaces
{
    /// <summary>
    /// Task priority repository interface
    /// </summary>
    public interface ITaskPriorityRepository : IAsyncRepository<TaskPriority>
    {
    }
}
