using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.ProjectUsers
{
    public class ProjectUserDto : EntityDto<Guid>
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }
    }
}
