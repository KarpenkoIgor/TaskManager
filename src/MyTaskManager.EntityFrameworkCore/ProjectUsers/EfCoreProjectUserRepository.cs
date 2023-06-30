using Microsoft.EntityFrameworkCore;
using MyTaskManager.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace MyTaskManager.ProjectUsers
{
    public class EfCoreProjectUserRepository : EfCoreRepository<MyTaskManagerDbContext, ProjectUser, Guid>, IProjectUserRepository
    {
        public EfCoreProjectUserRepository(IDbContextProvider<MyTaskManagerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }
    }
}
