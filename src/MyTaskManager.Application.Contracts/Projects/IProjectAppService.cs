using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MyTaskManager.Projects
{
    public interface IProjectAppService : IApplicationService
    {
        Task<ProjectDto> CreateAsync(ProjectCreateDto input);
    }
}
