using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
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
            var existingProjectUser = await _projectUserRepository.FirstOrDefaultAsync(
                x => x.UserId == userId && x.ProjectId == projectId);

            if (existingProjectUser != null)
            {
                throw new Exception("The ProjectUser entity with the same UserId and ProjectId already exists");
            }

            var projectUser = new ProjectUser(
                GuidGenerator.Create(),
                projectId,
                userId,
                role);

            return await _projectUserRepository.InsertAsync(projectUser);
        }

        public async Task<List<ProjectUser>> GetListAsync()
        {
            return await _projectUserRepository.GetListAsync();
        }
        public async Task<ProjectUser> GetAsync(Guid id)
        {
            return await _projectUserRepository.GetAsync(id);
        }
/*        public async Task<List<ProjectUser>> GetListByUserIdAsync(Guid id)
        {

        }
        public async Task<List<ProjectUser>> GetListByProjectIdAsync(Guid id)
        {

        }*/

        public async Task DeleteAsync(Guid id)
        {
            await _projectUserRepository.DeleteAsync(id);
        }
        public async Task<long> GetCountAsync()
        {
            return await _projectUserRepository.GetCountAsync();
        }
    }
}
