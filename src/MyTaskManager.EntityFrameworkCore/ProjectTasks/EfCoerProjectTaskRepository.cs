using MyTaskManager.EntityFrameworkCore;
using MyTaskManager.ProjectUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyTaskManager.ProjectTasks
{
    public class EfCoreProjectTaskRepository : EfCoreRepository<MyTaskManagerDbContext, ProjectTask, Guid>, ITaskRepository
    {
        public EfCoreProjectTaskRepository(IDbContextProvider<MyTaskManagerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
