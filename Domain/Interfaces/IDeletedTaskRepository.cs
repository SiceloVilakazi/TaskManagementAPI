
using Domain.Entities;
using Domain.Generic;

namespace Domain.Interfaces
{
    /// <summary>
    /// Deleted Task repository interface
    /// </summary>
    public interface IDeletedTaskRepository : IAsyncRepository<DeletedTask>
    {
    }
}
