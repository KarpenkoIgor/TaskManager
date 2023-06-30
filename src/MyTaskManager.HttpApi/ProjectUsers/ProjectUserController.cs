using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace MyTaskManager.ProjectUsers
{
    [RemoteService(Name = "Tasks")]
    [Area("Tasks")]
    [ControllerName("ProjectUser")]
    [Route("api/project-users")]

    public  class ProjectUserController : MyTaskManagerController
    {
        private readonly IProjectUserAppService _projectUserAppService;

        public ProjectUserController(IProjectUserAppService projectUserAppService)
        {
            _projectUserAppService = projectUserAppService;
        }

        [HttpPost]
        public virtual Task<ProjectUserDto> CreateAsync(ProjectUserCreateDto input)
        {
            return _projectUserAppService.CreateAsync(input);
        }
    }
}
