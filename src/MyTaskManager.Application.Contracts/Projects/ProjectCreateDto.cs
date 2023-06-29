using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskManager.Projects
{
    public class ProjectCreateDto
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
