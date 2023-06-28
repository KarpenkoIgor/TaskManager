using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace MyTaskManager.Tasks
{
    public class Comment : Entity<Guid>
    {
        public string Text { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }

    }
}
