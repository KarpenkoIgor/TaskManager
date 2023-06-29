using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace MyTaskManager.ProjectUsers
{
    public class ProjectUserManager : DomainService
    {
        private readonly IProjectUserRepository _projectUserRepository;

        public ProjectUserManager(IProjectUserRepository projectUserRepository)
        {
            _projectUserRepository = projectUserRepository;
        }

        public async Task<ProjectUser> CreateAsync(
            Guid projectId,
            Guid userId,
            ProjectRole role = ProjectRole.Undefined)
        {

            var project = new ProjectUser(
                GuidGenerator.Create(),
                projectId,
                userId,
                role);

            return await _projectUserRepository.InsertAsync(project);
        }
    }
}
