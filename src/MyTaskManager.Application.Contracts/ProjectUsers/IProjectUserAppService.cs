using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTaskManager.ProjectUsers
{
    public interface IProjectUserAppService
    {
        Task<ProjectUserDto> CreateAsync(ProjectUserCreateDto input);
    }
}
