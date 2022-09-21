using Domain.Entities;
using Domain.Generic;

namespace Domain.Interfaces
{
    /// <summary>
    /// Repository interface for deleted reason
    /// </summary>
    public interface IDeletedReasonRepository : IAsyncRepository<DeletedReason>
    {
    }
}
