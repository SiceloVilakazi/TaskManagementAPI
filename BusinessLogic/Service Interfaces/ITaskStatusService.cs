using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the logic for task statuses
    /// </summary>
    public interface ITaskStatusService
    {
        /// <summary>
        /// gets a list of all task statuses
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<GetTaskStatusesDTO>> GetAllTaskStatuses();
    }
}
