using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskManager.ProjectUsers
{
    public class ProjectUserCreateUpdateDto
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public ProjectRole Role { get; set; }
    }
}
