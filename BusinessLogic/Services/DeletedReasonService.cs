using AutoMapper;
using Domain.Generic;
using Domain.Interfaces;
using Models.DTOs;

namespace BusinessLogic
{
    /// <summary>
    /// Handles all the logical operations for deleted reasons
    /// </summary>
    public class DeletedReasonService : BaseService, IDeletedReasonService
    {
        private readonly IDeletedReasonRepository _deletedReasonRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes the constructor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="deletedReasonRepository"></param>
        /// <param name="mapper"></param>
        public DeletedReasonService(IUnitOfWork unitOfWork,
                                    IDeletedReasonRepository deletedReasonRepository,
                                    IMapper mapper) : base(unitOfWork)
        {
            
            _deletedReasonRepository = deletedReasonRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets a list of all deleted reasons
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<GetDeletedReasonsDTO>> GetAllDeletedReasons()
        {
            var deletedReasons = await _deletedReasonRepository.ListByExpressionAsync(x => x.Deleted != 1);
            var result = _mapper.Map<List<GetDeletedReasonsDTO>>(deletedReasons);
            return result;
        }
    }
}
