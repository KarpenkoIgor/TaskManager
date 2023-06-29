using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MyTaskManager.Projects
{
    public class ProjectDto : EntityDto<Guid>
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
