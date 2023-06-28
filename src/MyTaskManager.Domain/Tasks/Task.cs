using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace MyTaskManager.Tasks
{
    public class Task : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid ProjectId { get; set; }
        public Guid AssingnedUserId { get; set; }
        public DateTime DeadLine { get; set; }
        public bool IsClosed { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public Task(
            Guid id,
            string name,
            Guid projectId,
            Guid assignedUserId,
            DateTime deadLine,
            string description = null
            ) : base(id)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name));
            Description = description;
            AssingnedUserId = assignedUserId;
            ProjectId = projectId;
            DeadLine = deadLine;
            IsClosed = false;
            Comments = new Collection<Comment>();
        }
        private Task() { }
    }
}
