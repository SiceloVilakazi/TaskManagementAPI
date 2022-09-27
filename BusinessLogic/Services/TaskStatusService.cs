using AutoMapper;
using Domain.Generic;
using Domain.Interfaces;
using Models.DTOs;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the logic for task statuses
    /// </summary>
    public class TaskStatusService : BaseService, ITaskStatusService
    {
        private readonly ITaskStatusRepository _taskStatusRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <param name="taskStatusRepository"></param>
        public TaskStatusService(IUnitOfWork unitOfWork,
            IMapper mapper, ITaskStatusRepository taskStatusRepository) : base(unitOfWork)
        {
            _mapper = mapper;
            _taskStatusRepository = taskStatusRepository;
        }

        /// <summary>
        /// gets a list of all task statuses
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetTaskStatusesDTO>> GetAllTaskStatuses()
        {
            var taskStatuses = await _taskStatusRepository.ListByExpressionAsync(x => x.Deleted != 1);
            var result = _mapper.Map<List<GetTaskStatusesDTO>>(taskStatuses);
            return result;
        }
    }
}
