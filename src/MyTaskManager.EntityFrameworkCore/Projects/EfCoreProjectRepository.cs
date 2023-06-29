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

namespace MyTaskManager.Projects
{
    public class EfCoreProjectRepository : EfCoreRepository<MyTaskManagerDbContext, Project, Guid>, IProjectRepository
    {
        public EfCoreProjectRepository(IDbContextProvider<MyTaskManagerDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //public async Task<List<CourseCategory>> GetListAsync(
        //    string filterText = null,
        //    string name = null,
        //    bool? isSystem = null,
        //    bool? isDefault = null,
        //    string sorting = null,
        //    int maxResultCount = int.MaxValue,
        //    int skipCount = 0,
        //    CancellationToken cancellationToken = default)
        //{
        //    var query = ApplyFilter((await GetQueryableAsync()), filterText, name, isSystem, isDefault);
        //    query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CourseCategoryConsts.GetDefaultSorting(false) : sorting);
        //    return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        //}

        //public async Task<long> GetCountAsync(
        //    string filterText = null,
        //    string name = null,
        //    bool? isSystem = null,
        //    bool? isDefault = null,
        //    CancellationToken cancellationToken = default)
        //{
        //    var query = ApplyFilter((await GetDbSetAsync()), filterText, name, isSystem, isDefault);
        //    return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        //}

        //protected virtual IQueryable<CourseCategory> ApplyFilter(
        //    IQueryable<CourseCategory> query,
        //    string filterText,
        //    string name = null,
        //    bool? isSystem = null,
        //    bool? isDefault = null)
        //{
        //    return query
        //            .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText))
        //            .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
        //            .WhereIf(isSystem.HasValue, e => e.IsSystem == isSystem)
        //            .WhereIf(isDefault.HasValue, e => e.IsDefault == isDefault);
        //}
    }
}
