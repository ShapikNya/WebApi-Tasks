using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Common.Mappings;
using Tasks.Application.Tasks.Queries.GetTaskDetails;

namespace Tasks.Application.Tasks.Queries.GetTaskList
{
    public class TaskLookupDto : IMapWith<Domain.Task>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskDetailsVm>()
                .ForMember(taskDto => taskDto.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(taskDto => taskDto.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskDto => taskDto.IsCompleted,
                    opt => opt.MapFrom(task => task.IsCompleted))
                .ForMember(taskDto => taskDto.CreatedAt,
                    opt => opt.MapFrom(task => task.CreatedAt));
        }
    }
}
