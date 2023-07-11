using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Controllers;
using MyTaskManager.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.ProjectUsers
{
    [RemoteService(Name = "Tasks")]
    [Area("Tasks")]
    [ControllerName("ProjectUser")]

    public  class ProjectUserController : MyTaskManagerController
    {
        private readonly IProjectUserAppService _projectUserAppService;

        public ProjectUserController(IProjectUserAppService projectUserAppService)
        {
            _projectUserAppService = projectUserAppService;
        }

        [HttpPost]
        [Route("api/project-users/post")]
        public virtual Task<ProjectUserDto> CreateAsync(ProjectUserCreateUpdateDto input)
        {
            return _projectUserAppService.CreateAsync(input);
        }

        [HttpGet]
        [Route("api/project-users/get")]
        public virtual Task<PagedResultDto<ProjectUserDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _projectUserAppService.GetListAsync(input);
        }

        [HttpPut]
        [Route("api/project-users/put/{id}")]
        public virtual Task UpdateAsync(Guid id, ProjectUserCreateUpdateDto input)
        {
            return _projectUserAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("api/project-users/delete/{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _projectUserAppService.DeleteAsync(id);
        }
    }
}
