using MyTaskManager.Projects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.ProjectUsers
{
    public interface IProjectUserAppService
    {
        Task<ProjectUserDto> CreateAsync(ProjectUserCreateUpdateDto input);
        Task<PagedResultDto<ProjectUserDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<ProjectUserDto> GetAsync(Guid id);
        /*        Task<ProjectUserDto> GetByUserIdAsync(Guid userId);
        Task<ProjectUserDto> GetByProjectIdAsync(Guid projectId);*/
        Task UpdateAsync(Guid id, ProjectUserCreateUpdateDto input);
        Task DeleteAsync(Guid id);
    }
}
