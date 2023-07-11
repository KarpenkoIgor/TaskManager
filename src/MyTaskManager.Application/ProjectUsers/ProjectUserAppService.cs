using MyTaskManager.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.ObjectMapping;

namespace MyTaskManager.ProjectUsers
{
    [RemoteService(IsEnabled = false)]
    public class ProjectUserAppService : MyTaskManagerAppService, IProjectUserAppService
    {
        private readonly ProjectUserManager _projectUserManager;

        public ProjectUserAppService (ProjectUserManager projectUserManager)
        {
            _projectUserManager = projectUserManager;
        }

        public virtual async Task<ProjectUserDto> CreateAsync(ProjectUserCreateUpdateDto input)
        {

            var project = await _projectUserManager.CreateAsync(
                input.ProjectId,
                input.UserId,
                input.Role);


            return ObjectMapper.Map<ProjectUser, ProjectUserDto>(project);
        }
        public virtual async Task<PagedResultDto<ProjectUserDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var project = await _projectUserManager.GetListAsync();
            var count = await _projectUserManager.GetCountAsync();
            return new PagedResultDto<ProjectUserDto>(
                count,
                ObjectMapper.Map<List<ProjectUser>, List<ProjectUserDto>>(project)
                );
        }

        public virtual async Task<ProjectUserDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ProjectUser, ProjectUserDto>(
                await _projectUserManager.GetAsync(id)
                );            
        }

        public virtual async Task UpdateAsync(Guid id, ProjectUserCreateUpdateDto input)
        {
            var project = await _projectUserManager.GetAsync(id);
            ObjectMapper.Map(input, project);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _projectUserManager.DeleteAsync(id);
        }
    }
}
