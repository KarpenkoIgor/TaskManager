using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace MyTaskManager.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<ProjectDto> CreateAsync(ProjectCreateDto input);
        Task<PagedResultDto<ProjectDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<ProjectDto> GetAsync(Guid projectId);
        Task UpdateAsync(Guid id , ProjectUpdateDto input);
        Task DeleteAsync(Guid id);

    }
}
