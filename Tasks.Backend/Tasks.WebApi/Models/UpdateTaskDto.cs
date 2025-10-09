using AutoMapper;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Application.Tasks.Commands.UpdateNote;

namespace Tasks.WepApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Title,
                    opt => opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.IsCompleted,
                        opt => opt.MapFrom(taskDto => taskDto.IsCompleted));
        }
    }
}
