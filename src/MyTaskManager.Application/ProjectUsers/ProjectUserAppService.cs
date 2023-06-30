using MyTaskManager.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

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

        public virtual async Task<ProjectUserDto> CreateAsync(ProjectUserCreateDto input)
        {

            var project = await _projectUserManager.CreateAsync(
                input.ProjectId,
                input.UserId,
                input.Role);


            return ObjectMapper.Map<ProjectUser, ProjectUserDto>(project);
        }
    }
}
