using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace MyTaskManager.ProjectUsers
{
    public interface IProjectUserRepository : IRepository<ProjectUser, Guid>
    {
    }
}
