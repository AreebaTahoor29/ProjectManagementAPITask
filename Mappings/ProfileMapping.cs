using AutoMapper;
using ProjectManagementAPI.Dtos;

namespace ProjectManagementAPI.Mappings
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            CreateMap<TaskDto, ProjectTask>();
            CreateMap<ProjectDto, Project>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks));

            CreateMap<UpdateProjectDto, Project>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<ProjectTaskDto, ProjectTask>();
            CreateMap<UpdateProjectTaskDto, ProjectTask>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
