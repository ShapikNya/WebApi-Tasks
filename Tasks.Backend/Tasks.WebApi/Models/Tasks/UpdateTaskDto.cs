using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Tasks.Commands.CreateTask;
using Tasks.Application.Tasks.Commands.UpdateNote;

namespace Tasks.WebApi.Models.Tasks
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        [Required]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }


        public void Mapping(Profile profile)
        {

            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Id,
                    opt => opt.MapFrom(taskDto => taskDto.Id))
                .ForMember(taskCommand => taskCommand.Title,
                    opt => opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(taskDto => taskDto.Description))
                .ForMember(taskCommand => taskCommand.IsCompleted,
                        opt => opt.MapFrom(taskDto => taskDto.IsCompleted));
        }
    }
}
