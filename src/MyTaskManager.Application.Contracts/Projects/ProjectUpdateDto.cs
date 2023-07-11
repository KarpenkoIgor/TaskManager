using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskManager.Projects
{
    public class ProjectUpdateDto
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime DeadLine { get; set; }
    }
}
