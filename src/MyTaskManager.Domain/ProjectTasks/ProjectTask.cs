using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;
using MyTaskManager.Comments;

namespace MyTaskManager.ProjectTasks
{
    public class ProjectTask : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectUserId { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ProjectTask(
            Guid id,
            string name,
            Guid projectUserId,
            DateTime deadLine,
            string description = null
            ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
            ProjectUserId = projectUserId;
            DeadLine = deadLine;
            IsClosed = false;
            Comments = new Collection<Comment>();
        }
        private ProjectTask() { }
    }
}
