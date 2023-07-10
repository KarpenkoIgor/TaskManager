using AutoMapper;
using MyTaskManager.Projects;
using MyTaskManager.ProjectUsers;
using System.Collections.Generic;

namespace MyTaskManager;

public class MyTaskManagerApplicationAutoMapperProfile : Profile
{
    public MyTaskManagerApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Project, ProjectDto>();
        CreateMap<ProjectUser, ProjectUserDto>();

    }
}
