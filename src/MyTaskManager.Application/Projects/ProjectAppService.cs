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

        public virtual async Task<PagedResultDto<ProjectDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var project = await _projectManager.GetListProjects();
            var count = await _projectManager.GetCountAsync();
            return new PagedResultDto<ProjectDto>(
                count, 
                ObjectMapper.Map<List<Project>, List<ProjectDto>>(project)
                ); 
        }

        public virtual async Task<ProjectDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Project, ProjectDto>(
                    await _projectManager.GetAsync(id)
                );
        }

        public virtual async Task UpdateAsync(Guid id, ProjectUpdateDto input)
        {
            var project = await _projectManager.GetAsync(id);
            ObjectMapper.Map(input, project); 
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _projectManager.DeleteAsync(id);
        }
    }
}
