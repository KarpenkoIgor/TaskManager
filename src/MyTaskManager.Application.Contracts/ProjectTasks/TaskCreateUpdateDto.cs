using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskManager.ProjectTasks
{
    public class TaskCreateUpdateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectUserId { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsClosed { get; set; }
    }
}
