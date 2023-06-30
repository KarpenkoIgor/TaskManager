using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskManager.ProjectUsers
{
    public class ProjectUserCreateDto
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }
    }
}
