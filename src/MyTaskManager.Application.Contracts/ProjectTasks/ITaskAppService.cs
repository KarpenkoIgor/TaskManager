using MyTaskManager.ProjectUsers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.ProjectTasks
{
    public interface ITaskAppService
    {
        Task<TaskDto> CreateAsync(TaskCreateUpdateDto input);
        Task<PagedResultDto<TaskDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        Task<TaskDto> GetAsync(Guid id);
        Task UpdateAsync(Guid id, TaskCreateUpdateDto input);
        Task DeleteAsync(Guid id);
    }
}
