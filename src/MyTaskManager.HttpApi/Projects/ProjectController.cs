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

namespace MyTaskManager.Projects
{
    [RemoteService(Name = "Tasks")]
    [Area("Tasks")]
    [ControllerName("Project")]

    public class ProjectController : MyTaskManagerController
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        [HttpPost]
        [Route("api/projects/post")]
        public virtual Task<ProjectDto> CreateAsync(ProjectCreateDto input)
        {
            return _projectAppService.CreateAsync(input);
        }

        [HttpGet]
        [Route("api/projects/get")]
        public virtual Task<PagedResultDto<ProjectDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _projectAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("api/projects/get/{id}")]
        public virtual Task<ProjectDto> GetAsync(Guid id)
        {
            return _projectAppService.GetAsync(id);
        }

        [HttpPut]
        [Route("api/projects/put/{id}")]
        public virtual Task UpdateAsync(Guid id, ProjectUpdateDto input)
        {
            return _projectAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("api/projects/delete/{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _projectAppService.DeleteAsync(id);
        }
    }
}
