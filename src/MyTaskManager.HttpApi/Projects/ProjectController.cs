using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace MyTaskManager.Projects
{
    [RemoteService(Name = "Tasks")]
    [Area("Tasks")]
    [ControllerName("Project")]
    [Route("api/projects")]

    public  class ProjectController : MyTaskManagerController
    {
        private readonly IProjectAppService _projectAppService;

        public ProjectController(IProjectAppService projectAppService)
        {
            _projectAppService = projectAppService;
        }

        [HttpPost]
        public virtual Task<ProjectDto> CreateAsync(ProjectCreateDto input)
        {
            return _projectAppService.CreateAsync(input);
        }
    }
}
