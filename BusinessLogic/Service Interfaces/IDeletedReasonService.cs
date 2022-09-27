using Models.DTOs;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the logic for deleted reasons operations
    /// </summary>
    public interface IDeletedReasonService
    {
        /// <summary>
        /// Gets a list of all deleted reasons
        /// </summary>
        /// <returns>List</returns>
        Task<IEnumerable<GetDeletedReasonsDTO>> GetAllDeletedReasons();
    }
}
