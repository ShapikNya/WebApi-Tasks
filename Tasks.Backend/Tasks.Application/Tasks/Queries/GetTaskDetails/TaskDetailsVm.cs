using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Application.Common.Mappings;

namespace Tasks.Application.Tasks.Queries.GetTaskDetails
{
    public class TaskDetailsVm : IMapWith<Domain.Task>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskDetailsVm>()
                .ForMember(taskVm => taskVm.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(taskVm => taskVm.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(TaskVm => TaskVm.IsCompleted,
                    opt => opt.MapFrom(task => task.IsCompleted))
                .ForMember(TaskVm => TaskVm.CreatedAt,
                    opt => opt.MapFrom(task => task.CreatedAt));
        }

    }
}
