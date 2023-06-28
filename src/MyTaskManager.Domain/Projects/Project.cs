using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp;

namespace MyTaskManager.Projects
{
    public class Project : AuditedAggregateRoot<Guid>
    {
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime DeadLine { get; set; }

        public Project(
            Guid id,
            string name,
            DateTime deadLine,
            string description = null
            ) : base(id)
        {
            ProjectName = Check.NotNullOrWhiteSpace(name, nameof(name));
            ProjectDescription = description;
            DeadLine = deadLine;
        }
        private Project() { }
    }
}
