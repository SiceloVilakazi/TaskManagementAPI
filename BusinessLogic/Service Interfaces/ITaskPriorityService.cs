using Models.DTOs;


namespace BusinessLogic
{
    /// <summary>
    /// Handles all the logic for managing task priorities
    /// </summary>
    public interface ITaskPriorityService
    {
        /// <summary>
        /// gets a list of all task priorities
        /// </summary>
        /// <returns></returns>
       Task<IEnumerable<GetTaskPriorityDTO>> GetAllTaskPriorities();
    }
}
