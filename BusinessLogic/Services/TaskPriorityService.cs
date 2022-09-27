using AutoMapper;
using Domain.Generic;
using Domain.Interfaces;
using Models.DTOs;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the logic for managing task priorities
    /// </summary>
    public class TaskPriorityService : BaseService, ITaskPriorityService
    {
        private readonly ITaskPriorityRepository _taskPriorityRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="taskPriorityRepository"></param>
        /// <param name="mapper"></param>
        public TaskPriorityService(IUnitOfWork unitOfWork,
            ITaskPriorityRepository taskPriorityRepository,
            IMapper mapper) : base(unitOfWork)
        {
            _taskPriorityRepository = taskPriorityRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// gets a list of all task priorities
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetTaskPriorityDTO>> GetAllTaskPriorities()
        {
            var taskPriorities =await _taskPriorityRepository.ListByExpressionAsync(x => x.Deleted != 1);
            var result = _mapper.Map<List<GetTaskPriorityDTO>>(taskPriorities);
            return result;
        }
    }
}
