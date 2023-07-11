using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.ProjectTasks
{
    [RemoteService(Name = "Tasks")]
    [Area("Tasks")]
    [ControllerName("Task")]
    public class TaskController : MyTaskManagerController
    {
        private readonly ITaskAppService _taskAppService;

        public TaskController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [HttpPost]
        [Route("api/project-tasks/post")]
        public virtual Task<TaskDto> CreateAsync(TaskCreateUpdateDto input)
        {
            return _taskAppService.CreateAsync(input);
        }

        [HttpGet]
        [Route("api/project-tasks/get")]
        public virtual Task<PagedResultDto<TaskDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _taskAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("api/project-tasks/put/{id}")]
        public virtual Task UpdateAsync(Guid id, TaskCreateUpdateDto input)
        {
            return _taskAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("api/project-tasks/delete/{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _taskAppService.DeleteAsync(id);
        }
    }
}
