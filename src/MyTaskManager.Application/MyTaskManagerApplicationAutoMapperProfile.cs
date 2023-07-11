using AutoMapper;
using MyTaskManager.Projects;
using MyTaskManager.ProjectTasks;
using MyTaskManager.ProjectUsers;
using System.Collections.Generic;

namespace MyTaskManager;

public class MyTaskManagerApplicationAutoMapperProfile : Profile
{
    public MyTaskManagerApplicationAutoMapperProfile()
    {
        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectCreateDto, Project>();
        CreateMap<ProjectUpdateDto, Project>();
        CreateMap<ProjectUser, ProjectUserDto>();
        CreateMap<ProjectUserCreateUpdateDto, ProjectUser>();
        CreateMap<ProjectTask, TaskDto>();
        CreateMap<TaskCreateUpdateDto, ProjectTask>();
    }
}
