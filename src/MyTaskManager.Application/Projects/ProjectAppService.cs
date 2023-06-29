using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.Projects
{
    [RemoteService(IsEnabled = false)]
    public class ProjectAppService : MyTaskManagerAppService, IProjectAppService
    {
        private readonly ProjectManager _projectManager;
        public ProjectAppService(ProjectManager projectManager)
        {

            _projectManager = projectManager;
        }

        public virtual async Task<ProjectDto> CreateAsync(ProjectCreateDto input)
        {

            var project = await _projectManager.CreateAsync(
                input.ProjectName,
                input.ProjectDescription,
                input.DeadLine);


            return ObjectMapper.Map<Project, ProjectDto>(project);
        }

    }




}
