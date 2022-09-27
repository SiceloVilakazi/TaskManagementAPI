using AutoMapper;
using Domain.Entities;
using Models.DTOs;

namespace Models.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region Map from DB to DTO
            CreateMap<GetDeletedReasonsDTO, DeletedReason>();
            CreateMap<GetTaskPriorityDTO, TaskPriority>();
            CreateMap<GetTaskStatusesDTO, Domain.Entities.TaskStatus>();
            #endregion
        }
    }
}
