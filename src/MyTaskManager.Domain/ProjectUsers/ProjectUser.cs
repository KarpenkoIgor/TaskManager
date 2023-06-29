using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MyTaskManager.ProjectUsers
{
    public class ProjectUser : AggregateRoot<Guid>
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }

        public ProjectUser(
            Guid id,
            Guid projectId,
            Guid userId,
            ProjectRole role = ProjectRole.Undefined
            ) : base(id)
        {
            ProjectId = projectId;
            UserId = userId;
            Role = role;
        }
        private ProjectUser() { }
    }
}
