
using Domain.DBContext;
using Domain.Entities;
using Domain.Interfaces;
using Infastructure.Repositories;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// Provides operations for database related actions
    /// </summary>
    public class DeletedReasonRepository : BaseRepository<DeletedReason>, IDeletedReasonRepository
    {
        /// <summary>
        /// initializes the constructor
        /// </summary>
        /// <param name="dBContext"></param>
        public DeletedReasonRepository(TaskManagementDBContext dBContext) : base(dBContext)
        {
        }
    }
}
