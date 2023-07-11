using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.ProjectTasks
{
    [RemoteService(IsEnabled = false)]
    public class TaskAppService : MyTaskManagerAppService, ITaskAppService
    {
        private readonly TaskManager _taskManager;

        public TaskAppService(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public virtual async Task<TaskDto> CreateAsync(TaskCreateUpdateDto input)
        {
            var task = await _taskManager.CreateAsync(
                input.Name,
                input.ProjectUserId,
                input.DeadLine,
                input.Description);

            return ObjectMapper.Map<ProjectTask, TaskDto>(task);
        }
        public virtual async Task<PagedResultDto<TaskDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var task = await _taskManager.GetListAsync();
            var count = await _taskManager.GetCountAsync();
            return new PagedResultDto<TaskDto>(
                count,
                ObjectMapper.Map<List<ProjectTask>, List<TaskDto>>(task)
                );
        }

        public virtual async Task<TaskDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ProjectTask, TaskDto>(
                await _taskManager.GetAsync(id)
                );
        }

        public virtual async Task UpdateAsync(Guid id, TaskCreateUpdateDto input)
        {
            var task = await _taskManager.GetAsync(id);
            ObjectMapper.Map(input, task);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _taskManager.DeleteAsync(id);
        }
    }
}
