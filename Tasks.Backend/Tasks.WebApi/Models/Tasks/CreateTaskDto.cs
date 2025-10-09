using AutoMapper;
using System.ComponentModel.DataAnnotations;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Tasks.Commands.CreateTask;

namespace Tasks.WebApi.Models.Tasks
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        [Required]
        public string Title { get; set; }
        public string? Description { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Title,
                    opt => opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(taskCommand => taskCommand.Description,
                    opt => opt.MapFrom(noteDto => noteDto.Description));
        }
    }
}
